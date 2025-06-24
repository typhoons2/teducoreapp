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
                        id: item.id || item.Id,
                        text: item.name || item.Name,
                        parentId: item.parentId || item.ParentId,
                        sortOrder: item.sortOrder || item.SortOrder
                    });
                });
                var treeArr = tedu.unflatten(data);
                $('#treeProductCategory').tree({
                    data: treeArr,
                    dnd: true
                });
            }
        });
    }
}
