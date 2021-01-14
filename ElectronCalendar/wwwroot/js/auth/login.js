

require(['jquery'],
    function($) {
        require(['../js/app/services/userService'],
            function(service) {

                $(function() {
                    $('#login-form').on('submit',
                        function(e) {
                            e.preventDefault();
                            service.sendLogin();
                        });

                });

            });
    });
