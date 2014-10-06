$(document).ready(function () {

    $('#tabs li').on('click', function () {

        var tabId = $(this).data('tab-id');
        var activeTab = $('.active');
        var selectedTab = $('#' + tabID);
        activeTab.removeClass('active');
        activeTab.addClass('hide');
        selectedTab.removeClass('hide').addClass('active');
    });

    $('#contactForm').on('click', '.btnprimary', function (event) {
        event.preventDefault();
        if ($(this).valid()) {
            var urlToPostTo = $(this).data('action');
            alert(urlToPostTo);

            var dataToSend = $(this).parent().serialize();
            alert(dataToSend);
            $.post(urlToPostTo, dataToSend, function (data) {
                $('.contactContainer').html(data);
            });
        };
    });
});