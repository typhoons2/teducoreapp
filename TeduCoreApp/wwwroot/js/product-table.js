$(document).ready(function() {
    // Collapse/Expand Panel
    $('.collapse-link').on('click', function() {
        var $BOX_PANEL = $(this).closest('.x_panel');
        var $ICON = $(this).find('i');
        var $BOX_CONTENT = $BOX_PANEL.find('.x_content');
        
        // fix for some div with hardcoded fix
        if ($BOX_PANEL.attr('style')) {
            $BOX_CONTENT.slideToggle(200, function () {
                $BOX_PANEL.removeAttr('style');
            });
        } else {
            $BOX_CONTENT.slideToggle(200);
            $BOX_PANEL.css('height', 'auto');
        }
        
        $ICON.toggleClass('fa-chevron-up fa-chevron-down');
    });

    // Close Panel
    $('.close-link').on('click', function() {
        var $BOX_PANEL = $(this).closest('.x_panel');
        $BOX_PANEL.remove();
    });

    // Dropdown Menu
    $('.dropdown-toggle').on('click', function(e) {
        e.preventDefault();
        $(this).next('.dropdown-menu').toggle();
    });

    // Close dropdown when clicking outside
    $(document).on('click', function(e) {
        if (!$(e.target).closest('.dropdown').length) {
            $('.dropdown-menu').hide();
        }
    });

    // Checkbox "Select All"
    $('#check-all').on('click', function() {
        $('input[name="table_records"]').prop('checked', this.checked);
        updateBulkActions();
    });

    // Individual checkboxes
    $('input[name="table_records"]').on('click', function() {
        updateBulkActions();
    });

    function updateBulkActions() {
        var checkedCount = $('input[name="table_records"]:checked').length;
        $('.action-cnt').text(checkedCount);
    }

    // Bulk Actions
    $('.bulk-actions a').on('click', function(e) {
        e.preventDefault();
        var checkedItems = $('input[name="table_records"]:checked');
        if (checkedItems.length === 0) {
            alert('Please select at least one item');
            return;
        }
        
        var action = prompt('Enter action (delete, edit, etc.):');
        if (action) {
            // Handle bulk action here
            console.log('Bulk action:', action, 'on', checkedItems.length, 'items');
        }
    });

    // Row hover effect
    $('.table tbody tr').hover(
        function() {
            $(this).addClass('hover');
        },
        function() {
            $(this).removeClass('hover');
        }
    );

    // Search functionality
    $('#searchInput').on('keyup', function() {
        var value = $(this).val().toLowerCase();
        $('.table tbody tr').filter(function() {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
}); 