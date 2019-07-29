function ajaxModal() {
    $(document).ready(function () {
        $.ajaxSetup({ cache: false });
        $("a[data-modal]").on("click", function (e) {
            $("#myModalContent").load(this.href, function () {
                $("#myModal").modal({
                    keyboard: true
                }, 'show');
                bindForm(this);
            });
            return false;
        });
    });

    function bindForm() {
        $('form', dialog).submit(function () {
            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (result) {
                    if (result.success) {
                        $("#myModal").modal('hide');
                        $("#EnderecoTarget").load(result.url); // carrega o resultado html para a div
                    } else {
                        $("#myModal").html(result);
                        bindForm(dialog);
                    }
                }
            });
            return false;
        });
    }
}