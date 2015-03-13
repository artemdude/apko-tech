$(document).ready(function () {

    $('#fbSendButton').click(function () {


        var container = $(this).parents('.FeedBackTable');
        var isValid = true;
        var errorMessage = '';

        if (container.find('#phoneBox').val() == '') {
            isValid = false;
            errorMessage = '- Вы не ввели телефон!\n';
        }

        if (container.find('#mailBox').val() != '') {

            if (!container.find('#mailBox').val().match(/\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/)) {
                isValid = false;
                errorMessage += '- Вы указали не корректный эмейл!\n';
            }
        }

        if (isValid == false) {
            alert("Заказ не отправлен\n" + errorMessage);
        }
        else {

            $('#FeedBackForm .fbLoader').show();

            var data = { name: $('#FeedBackForm #nameBox').val(), mail: $('#FeedBackForm #mailBox').val(), phone: $('#FeedBackForm #phoneBox').val(), message: $('#FeedBackForm #messageBox').val() };

            $.ajax({
                type: "post",
                url: "Feedback",
                data: data,
                dataType: "json",
                async: true,
                success: function (json) {

                    $('#FeedBackForm .fbLoader').hide();

                    if (json.Result == 'Error') {

                        if (json.Message != '' || json.Message != undefined) {
                            alert("Заказ не был отправлен.\n" + json.Message);
                        }
                        else {
                            alert("Ошибка. Попробуйте позже");
                        }

                    }
                    if (json.Result == 'Success') {
                        alert("Спасибо за сотруднечиство, мы свяжемся с Вами");
                        //container.find('#phoneBox').val('');
                        //container.find('#nameBox').val('');
                        container.find('#messageBox').val('');
                        //container.find('#mailBox').val('');
                    }
                },
                error: function () {
                    $('#FeedBackForm .fbLoader').hide();
                    alert("error");
                }
            });
        }


    });


});
