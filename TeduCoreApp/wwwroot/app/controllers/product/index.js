var productController = function () {
    this.initialize = function () {
        loadData();
    }
    function loadData() {
        $.ajax({
            type: 'GET',
            url: '/Admin/Product/GetAll',
            dataType: 'json',
            success: function (response) {
                var render = '';
                var template = $('#table-template').html();
                $.each(response, function (i, item) {
                    render += Mustache.render(template, {
                        Name: item.name,
                        CategoryName: item.productCategory ? item.productCategory.name : '',
                        Price: item.price,
                        Image: '<img src="' + item.image + '" width="50" />',
                        CreatedDate: tedu.dateTimeFormatJson(item.dateCreated),
                        Status: item.status == 0 ? '<span class="badge badge-success">Active</span>' : '<span class="badge badge-danger">Inactive</span>'
                    });
                });
                $('#tbl-content').html(render);
            },
            error: function () {
                alert('Cannot load data');
            }
        });
    }
}
