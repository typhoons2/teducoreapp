var productCategoryController = function () {
    this.initialize = function () {
        loadData();
    }

    function loadData() {
        $.ajax({
            url: '/Admin/ProductCategory/GetAll',
            dataType: 'json',
            success: function (response) {
                var data = [];
                $.each(response, function (i, item) {
                    data.push({
                        id: item.id ?? item.Id,
                        text: item.name ?? item.Name,
                        parentId: item.parentId ?? item.ParentId,
                        sortOrder: item.sortOrder ?? item.SortOrder
                    });
                });
                var treeArr = tedu.unflatten(data);

                // Đệ quy sắp xếp toàn bộ tree theo sortOrder
                function sortTree(nodes) {
                    nodes.sort(function(a, b) {
                        return (a.sortOrder || 0) - (b.sortOrder || 0);
                    });
                    nodes.forEach(function(node) {
                        if (node.children && node.children.length > 0) {
                            sortTree(node.children);
                        }
                    });
                }
                sortTree(treeArr);

                $('#treeProductCategory').tree({
                    data: treeArr,
                    dnd: true,
                    onDrop: function (target, source, point) {
                        console.log(target);
                        console.log(source);
                        console.log(point);
                        var targetNode = $(this).tree('getNode', target);
                        if (point === 'append') {
                            // Lấy lại toàn bộ node con của parent mới từ tree (bao gồm cả node vừa kéo)
                            var allChildren = [];
                            var treeChildren = $('#treeProductCategory').tree('getChildren', targetNode.target);
                            if (treeChildren && treeChildren.length > 0) {
                                treeChildren.forEach(function(item) {
                                    allChildren.push(item);
                                });
                            }
                            // Đảm bảo source cũng nằm trong allChildren
                            if (!allChildren.some(function(item) { return item.id === source.id; })) {
                                allChildren.push(source);
                            }
                            // Gán lại sortOrder mới
                            var items = [];
                            $.each(allChildren, function (i, item) {
                                items.push({
                                    key: item.id,
                                    value: i * 10
                                });
                            });

                            $.ajax({
                                url: '/Admin/ProductCategory/UpdateParentId',
                                type: 'post',
                                dataType: 'json',
                                data: {
                                    sourceId: source.id,
                                    targetId: targetNode.id,
                                    items: items
                                },
                                success: function (res) {
                                    loadData();
                                }
                            });
                        }
                        else if (point === 'top' || point === 'bottom') {
                            var parentNode = $(this).tree('getParent', targetNode.target);
                            var siblings = parentNode ? parentNode.children.slice() : $('#treeProductCategory').tree('getRoots').slice();

                            // Xác định vị trí cũ và mới
                            var sourceIndex = siblings.findIndex(function(item) { return item.id === source.id; });
                            var targetIndex = siblings.findIndex(function(item) { return item.id === targetNode.id; });

                            // Xóa source khỏi vị trí cũ
                            if (sourceIndex > -1) siblings.splice(sourceIndex, 1);

                            // Tính vị trí mới để chèn
                            if (point === 'top') {
                                siblings.splice(targetIndex, 0, source);
                            } else {
                                siblings.splice(targetIndex + 1, 0, source);
                            }

                            // Gán lại sortOrder mới
                            var children = [];
                            $.each(siblings, function (i, item) {
                                children.push({
                                    key: item.id,
                                    value: i * 10
                                });
                            });

                            $.ajax({
                                url: '/Admin/ProductCategory/UpdateParentId',
                                type: 'post',
                                dataType: 'json',
                                data: {
                                    sourceId: source.id,
                                    targetId: parentNode ? parentNode.id : 0,
                                    items: children
                                },
                                success: function (res) {
                                    loadData();
                                }
                            });
                        }
                    }
                });
            }
        });
    }
}
