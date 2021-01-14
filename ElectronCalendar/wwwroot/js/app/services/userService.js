define(function(toastr, $) {
    
    // todo: fix it.
    function sendLogin() {
        var form = $('#login-form');
        if (!form.valid()) {
            toastr.error("Hey, verifique todos os campos!");
            return false;
        }

        $.ajax({
            type: 'POST',
            "contentType": 'application/json',
            dataType: 'json',
            data: JSON.stringify({
                searchTerm: $("#searchUser").val(),
                accountType: $("#accountType").val(),
                schoolId: $("#searchSchoolId").val()
            }),
            success: function(data) {
                if (!data) {
                    toastr.error("Usuário não encontrado!");
                    return;
                }
                if (data.fullName) {
                    $("#fullName").val(data.fullName);
                }

                if (data.username) {
                    $("#username").val(data.username);
                }

                if (data.renach) {
                    $("#renach").val(data.renach);
                    $("#password").val(data.renach);
                }
                toastr.success("Usuário carregado com sucesso!");
            },
            error: function(data) {

                $("#searchBtn").prop('disabled', false);
                toastr.error("Erro, tente novamente!");
            }

        });
    }

    return {
        sendLogin: sendLogin
    }
});