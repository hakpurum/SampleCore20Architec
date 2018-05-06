var App = {

    DataTableConfig: function () {
        var datatableLang = {
            "sProcessing": "İşleniyor...",
            "sLengthMenu": "Sayfada _MENU_ Kayıt Göster",
            "sZeroRecords": "Eşleşen Kayıt Bulunmadı",
            "sInfo": "  _TOTAL_ Kayıttan _START_ - _END_ Arası Kayıtlar",
            "sInfoEmpty": "Kayıt Yok",
            "sInfoFiltered": "( _MAX_ Kayıt İçerisinden Bulunan)",
            "sInfoPostFix": "",
            "sSearch": "Bul:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "İlk",
                "sPrevious": "Önceki",
                "sNext": "Sonraki",
                "sLast": "Son"
            }
        }
        return {
            "aoColumnDefs": [
                { "width": "10%", "targets": -1 },
                {
                    'bSortable': false, 'aTargets': [-1]
                }],
            "language": datatableLang,
            "scrollX": true,
            "iDisplayLength": 5,
            "aLengthMenu": [
                [5, 10, 25, 50, 100, -1], [5, 10, 25, 50, 100, "Tümü"]],
            "sDom": '<"dt-panelmenu clearfix"lfr>t<"dt-panelfooter clearfix"ip>',
            "oTableTools": {
                "sSwfPath": "/vendor/plugins/datatables/extensions/TableTools/swf/copy_csv_xls_pdf.swf"
            }
        };
    },
    Post: function (url, dataType, data, callback) {
        if (dataType == null)
            dataType = "json";

        waitingDialog.show("Lütfen bekleyiniz...");
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: dataType,
            url: url,
            data: data,
            success: function (response) {
                if (!response.ResultStatus) {
                    errorModal(response.ResultMessage); return;
                }

                if (response.ResultCode === 200 && response.ResultStatus) {
                    callback(response);
                }

            },
            error: function (jqXHR, textStatus, errorThrown) {
                errorModal(textStatus + errorThrown); return;
            }
        });
    },
    Get: function (url, dataType, data, callback) {
        if (dataType == null)
            dataType = "json";

        waitingDialog.show("Lütfen bekleyiniz...");
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: dataType,
            url: url,
            data: data,
            success: function (response) {
                if (!response.ResultStatus) {
                    errorModal(response.ResultMessage); return;
                }

                if (response.ResultCode === 200 && response.ResultStatus) {
                    callback(response);
                }

            },
            error: function (jqXHR, textStatus, errorThrown) {
                errorModal(textStatus + errorThrown); return;
            }
        });
    }
}

function errorModal(resultMessage, title) {
    if (title != null && title != "") {
        $(".modal-title").text(title);
    }
    if (resultMessage != null && resultMessage != "") {
        $(".modal-message").text(resultMessage);
    }
    $('#errorModal').modal('show');
}

$(document).ajaxComplete(function (event, request, settings) {
    waitingDialog.hide();
});

var waitingDialog = waitingDialog || (function ($) {
    'use strict';

    // Creating modal dialog's DOM
    var $dialog = $(
        '<div class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true" style="padding-top:15%; overflow-y:visible;">' +
        '<div class="modal-dialog modal-m">' +
        '<div class="modal-content">' +
        '<div class="modal-header"><h3 style="margin:0;"></h3></div>' +
        '<div class="modal-body">' +
        '<div class="progress progress-striped active" style="margin-bottom:0;"><div class="progress-bar" style="width: 100%"></div></div>' +
        '</div>' +
        '</div></div></div>');

    return {
        show: function (message, options) {
            // Assigning defaults
            if (typeof options === 'undefined') {
                options = {};
            }
            if (typeof message === 'undefined') {
                message = 'Loading';
            }
            var settings = $.extend({
                dialogSize: 'm',
                progressType: '',
                onHide: null // This callback runs after the dialog was hidden
            }, options);

            // Configuring dialog
            $dialog.find('.modal-dialog').attr('class', 'modal-dialog').addClass('modal-' + settings.dialogSize);
            $dialog.find('.progress-bar').attr('class', 'progress-bar');
            if (settings.progressType) {
                $dialog.find('.progress-bar').addClass('progress-bar-' + settings.progressType);
            }
            $dialog.find('h3').text(message);
            // Adding callbacks
            if (typeof settings.onHide === 'function') {
                $dialog.off('hidden.bs.modal').on('hidden.bs.modal', function (e) {
                    settings.onHide.call($dialog);
                });
            }
            // Opening dialog
            $dialog.modal();
        },
        /**
		 * Closes dialog
		 */
        hide: function () {
            $dialog.modal('hide');
        }
    };

})(jQuery);