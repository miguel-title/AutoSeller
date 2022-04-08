$(document).ready(function () {

    /* =================================================================
        Default Table
    ================================================================= */

    //$('#table-1').DataTable();

    /* =================================================================
       Exporting Table Data
    ================================================================= */

    //$('#table-2').DataTable( {
    //    dom: 'Bfrtip',
    //    buttons: [
    //        'copyHtml5',
    //        'excelHtml5',
    //        'csvHtml5',
    //        'pdfHtml5'
    //    ]
    //} );

    /* =================================================================
       Table with Column Filtering
    ================================================================= */

    var $table3 = jQuery("#table-3");

    var table3 = $table3.DataTable({
        "aLengthMenu": [[50, 100, 200, -1], [50, 100, 200, "All"]],
        //searching: false,
        //paging: false,
        "sDom": 'rtlfip'//,
        //info: false
    });

    // Setup - add a text input to each footer cell
    $('#table-3 thead th').each(function () {
        var title = $('#table-3 thead th').eq($(this).index()).text();
        if ($(this).index() == 0) {
            $(this).html('select all <input type="checkbox" onchange="SelectAll(this)" />');
        }
        else if ($(this).index() == 3) {
            $(this).html('<input class="form-control" type="date" id="example-date-input" placeholder="Search ' + title + '">');
        }
        else if ($(this).index() > 1 && $(this).index() != 3) {
            $(this).html('<input type="text" class="form-control" placeholder="Search ' + title + '" />');
        }
    });

    // Apply the search
    table3.columns().every(function () {
        var that = this;
        if (this.index() > 1) {
            $('input', this.header()).on('keyup change', function () {
                if ($(this).prop('id') == 'example-date-input') {
                    var value = '';
                    if (this.value.split('-').length == 3) {
                        var day = this.value.split('-')[2];
                        var month = this.value.split('-')[1];
                        var year = this.value.split('-')[0];
                        value = month + '/' + day + '/' + year;
                    }
                    if (that.search() !== value) {
                        that
                            .search(value)
                            .draw();
                    }
                }
                else {
                    if (that.search() !== this.value) {
                        that
                            .search(this.value)
                            .draw();
                    }
                }
            });
        }
    });

});
