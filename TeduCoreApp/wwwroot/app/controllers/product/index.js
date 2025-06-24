var productController = function () {
    this.initialize = function () {
        loadCategories();
        loadData();
        registerEvents();
    }

    function registerEvents() {
        $('#btnSearch').on('click', function () {
            loadData();
        });
        $('#txtKeyword').on('keypress', function (e) {
            if (e.which === 13) {
                loadData();
            }
        });
        $('#ddlShowPage').on('change', function() {
            tedu.config.pageSize = $(this).val();
            loadData(1);
        });
        $('#ddlCategorySearch').on('change', function() {
            loadData();
        });
    }

    function loadCategories() {
        $.ajax({
            type: 'GET',
            url: '/Admin/Product/GetAllCategories',
            dataType: 'json',
            success: function (response) {
                var render = "<option value=''>--Select category--</option>";
                $.each(response, function (i, item) {
                    render += "<option value='" + item.id + "'>" + item.name + "</option>";
                });
                $('#ddlCategorySearch').html(render);
            },
            error: function (status) {
                console.log(status);
                tedu.notify('Cannot loading product category data', 'error');
            }
        });
    }

    function loadData(pageIndex) {
        pageIndex = pageIndex || 1;
        $.ajax({
            type: 'GET',
            url: '/Admin/Product/GetAll',
            data: {
                page: pageIndex,
                pageSize: tedu.config.pageSize,
                categoryId: $('#ddlCategorySearch').val(),
                keyword: $('#txtKeyword').val()
            },
            dataType: 'json',
            success: function (response) {
                var render = '';
                var template = $('#table-template').html();
                $.each(response.results, function (i, item) {
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
                $('#lblTotalRecords').text('Tổng số bản ghi: ' + response.rowCount);
                // Destroy old pagination before re-init
                $('#pagination').twbsPagination('destroy');
                if (response.rowCount > 0) {
                    $('#pagination').twbsPagination({
                        totalPages: response.pageCount,
                        visiblePages: 7,
                        startPage: response.currentPage,
                        onPageClick: function (event, page) {
                            if (page !== pageIndex) {
                                loadData(page);
                            }
                        }
                    });
                }
            },
            error: function () {
                alert('Cannot load data');
            }
        });
    }
}
