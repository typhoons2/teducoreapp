var productCategoryController = function () {
    this.initialize = function () {
        loadData();
        registerEvents();
    }

    /* ======================= EVENT REGISTRATION ======================= */
    function registerEvents() {
        // Validate form
        if ($.validator) {
            $('#frmMaintainance').validate({
                errorClass: 'red',
                ignore: [],
                lang: 'en',
                rules: {
                    txtNameM: { required: true },
                    txtOrderM: { number: true },
                    txtHomeOrderM: { number: true }
                }
            });
        }

        // Show create modal
        $('#btnCreate').off('click').on('click', function () {
            resetFormMaintainance();
            initTreeDropDownCategory();
            $('#modal-add-edit').modal('show');
        });

        // Edit context menu
        $(document).on('click', '#btnEdit', function (e) {
            e.preventDefault();
            var id = $('#hidIdM').val();
            if (!id) return;
            $.ajax({
                type: 'GET',
                url: '/Admin/ProductCategory/GetById',
                data: { id: id },
                dataType: 'json',
                beforeSend: function () {
                    tedu.startLoading();
                },
                success: function (data) {
                    $('#hidIdM').val(data.id ?? data.Id);
                    $('#txtNameM').val(data.name ?? data.Name);
                    initTreeDropDownCategory(data.parentId ?? data.ParentId);
                    $('#txtDescM').val(data.description ?? data.Description);
                    $('#txtImageM').val(data.image ?? data.Image);
                    $('#txtSeoKeywordM').val(data.seoKeywords ?? data.SeoKeywords);
                    $('#txtSeoDescriptionM').val(data.seoDescription ?? data.SeoDescription);
                    $('#txtSeoPageTitleM').val(data.seoPageTitle ?? data.SeoPageTitle);
                    $('#txtSeoAliasM').val(data.seoAlias ?? data.SeoAlias);
                    $('#ckStatusM').prop('checked', (data.status ?? data.Status) == 1);
                    $('#ckShowHomeM').prop('checked', data.homeFlag ?? data.HomeFlag);
                    $('#txtOrderM').val(data.sortOrder ?? data.SortOrder);
                    $('#txtHomeOrderM').val(data.homeOrder ?? data.HomeOrder);

                    $('#modal-add-edit').modal('show');
                    tedu.stopLoading();
                },
                error: function () {
                    tedu.notify('Có lỗi xảy ra', 'error');
                    tedu.stopLoading();
                }
            });
        });

        // Delete context menu
        $(document).on('click', '#btnDelete', function (e) {
            e.preventDefault();
            var id = $('#hidIdM').val();
            if (!id) return;
            tedu.confirm('Are you sure to delete?', function () {
                $.ajax({
                    type: 'POST',
                    url: '/Admin/ProductCategory/Delete',
                    data: { id: id },
                    dataType: 'json',
                    beforeSend: function () {
                        tedu.startLoading();
                    },
                    success: function () {
                        tedu.notify('Deleted success', 'success');
                        tedu.stopLoading();
                        loadData();
                    },
                    error: function () {
                        tedu.notify('Has an error in deleting progress', 'error');
                        tedu.stopLoading();
                    }
                });
            });
        });

        // Save button
        $('#btnSave').off('click').on('click', function (e) {
            if ($('#frmMaintainance').valid()) {
                e.preventDefault();
                var id = parseInt($('#hidIdM').val());
                var name = $('#txtNameM').val();
                var parentId = $('#ddlCategoryIdM').combotree('getValue');
                var description = $('#txtDescM').val();
                var image = $('#txtImageM').val();
                var order = parseInt($('#txtOrderM').val());
                var homeOrder = $('#txtHomeOrderM').val();
                var seoKeyword = $('#txtSeoKeywordM').val();
                var seoMetaDescription = $('#txtSeoDescriptionM').val();
                var seoPageTitle = $('#txtSeoPageTitleM').val();
                var seoAlias = $('#txtSeoAliasM').val();
                var status = $('#ckStatusM').prop('checked') ? 1 : 0;
                var showHome = $('#ckShowHomeM').prop('checked');

                $.ajax({
                    type: 'POST',
                    url: '/Admin/ProductCategory/SaveEntity',
                    data: {
                        Id: id,
                        Name: name,
                        Description: description,
                        ParentId: parentId,
                        HomeOrder: homeOrder,
                        SortOrder: order,
                        HomeFlag: showHome,
                        Image: image,
                        Status: status,
                        SeoPageTitle: seoPageTitle,
                        SeoAlias: seoAlias,
                        SeoKeywords: seoKeyword,
                        SeoDescription: seoMetaDescription
                    },
                    dataType: 'json',
                    beforeSend: function () {
                        tedu.startLoading();
                    },
                    success: function () {
                        tedu.notify('Update success', 'success');
                        $('#modal-add-edit').modal('hide');
                        resetFormMaintainance();
                        tedu.stopLoading();
                        loadData();
                    },
                    error: function () {
                        tedu.notify('Has an error in update progress', 'error');
                        tedu.stopLoading();
                    }
                });
            }
            return false;
        });
    }

    /* ======================= HELPER FUNCTIONS ======================= */
    function resetFormMaintainance() {
        $('#hidIdM').val(0);
        $('#txtNameM').val('');
        initTreeDropDownCategory('');
        $('#txtDescM').val('');
        $('#txtOrderM').val('');
        $('#txtHomeOrderM').val('');
        $('#txtImageM').val('');
        $('#txtSeoKeywordM').val('');
        $('#txtSeoDescriptionM').val('');
        $('#txtSeoPageTitleM').val('');
        $('#txtSeoAliasM').val('');
        $('#ckStatusM').prop('checked', true);
        $('#ckShowHomeM').prop('checked', false);
    }

    function initTreeDropDownCategory(selectedId) {
        $.ajax({
            url: '/Admin/ProductCategory/GetAll',
            type: 'GET',
            dataType: 'json',
            async: false,
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
                $('#ddlCategoryIdM').combotree({
                    data: treeArr
                });
                if (selectedId !== undefined) {
                    $('#ddlCategoryIdM').combotree('setValue', selectedId);
                }
            }
        });
    }

    /* ======================= LOAD TREE ======================= */
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

                // Sort the tree by sortOrder recursively
                function sortTree(nodes) {
                    nodes.sort(function (a, b) { return (a.sortOrder || 0) - (b.sortOrder || 0); });
                    nodes.forEach(function (n) {
                        if (n.children && n.children.length > 0) {
                            sortTree(n.children);
                        }
                    });
                }
                sortTree(treeArr);

                $('#treeProductCategory').tree({
                    data: treeArr,
                    dnd: true,
                    onContextMenu: function (e, node) {
                        e.preventDefault();
                        $('#hidIdM').val(node.id);
                        $('#contextMenu').menu('show', { left: e.pageX, top: e.pageY });
                    },
                    onDrop: function (target, source, point) {
                        var targetNode = $(this).tree('getNode', target);
                        if (!targetNode) return;

                        if (point === 'append') {
                            // Build new sort order list among new siblings (targetNode children)
                            var allChildren = [];
                            var treeChildren = $('#treeProductCategory').tree('getChildren', targetNode.target);
                            if (treeChildren && treeChildren.length > 0) {
                                treeChildren.forEach(function (i) { allChildren.push(i); });
                            }
                            if (!allChildren.some(function (i) { return i.id === source.id; })) {
                                allChildren.push(source);
                            }
                            var items = [];
                            $.each(allChildren, function (i, it) {
                                items.push({ key: it.id, value: i * 10 });
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
                                success: function () {
                                    loadData();
                                }
                            });
                        }
                        else if (point === 'top' || point === 'bottom') {
                            var parentNode = $(this).tree('getParent', targetNode.target);
                            var siblings = parentNode ? parentNode.children.slice() : $('#treeProductCategory').tree('getRoots').slice();
                            var sourceIndex = siblings.findIndex(function (i) { return i.id === source.id; });
                            var targetIndex = siblings.findIndex(function (i) { return i.id === targetNode.id; });
                            if (sourceIndex > -1) siblings.splice(sourceIndex, 1);
                            if (point === 'top') {
                                siblings.splice(targetIndex, 0, source);
                            } else {
                                siblings.splice(targetIndex + 1, 0, source);
                            }
                            var children = [];
                            $.each(siblings, function (i, it) {
                                children.push({ key: it.id, value: i * 10 });
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
                                success: function () {
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
