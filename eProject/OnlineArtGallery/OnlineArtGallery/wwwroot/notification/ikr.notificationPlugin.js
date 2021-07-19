(function ($) {
    // ****** Add ikr.notification.css ******
    $.fn.ikrNotificationSetup = function (options) {
        /*
          Declaration : $("#noti_Container").ikrNotificationSetup({
                    List: objCollectionList
          });
       */
        var defaultSettings = $.extend({
            BeforeSeenColor: "#2E467C",
            AfterSeenColor: "#ccc"
        }, options);
        $(".ikrNoti_Button").css({
            "background": defaultSettings.BeforeSeenColor
        });
        var parentId = $(this).attr("id");
        if ($.trim(parentId) != "" && parentId.length > 0) {
            $("#" + parentId).append("<div class='ikrNoti_Counter'></div>" +
                "<div class='ikrNoti_Button'><i class='fas fa-bell'></i></div>" +
                "<div class='ikrNotifications'>" +
                "<h3>Notifications (<span class='notiCounterOnHead'>0</span>)</h3>" +
                "<div class='ikrNotificationItems'>" +
                "</div>" +
                "<div class='ikrSeeAll'><a href='#'>See All</a></div>" +
                "</div>");

            $('#' + parentId + ' .ikrNoti_Counter')
                .css({ opacity: 0 })
                .text(0)
                .css({ top: '-10px' })
                .animate({ top: '-2px', opacity: 1 }, 500);

            $('#' + parentId + ' .ikrNoti_Button').click(function () {
                $('#' + parentId + ' .ikrNotifications').fadeToggle('fast', 'linear', function () {
                    if ($('#' + parentId + ' .ikrNotifications').is(':hidden')) {
                        //$('#' + parentId + ' .ikrNoti_Button').css('background-color', defaultSettings.AfterSeenColor);
                    }
                    //else $('#' + parentId + ' .ikrNoti_Button').css('background-color', defaultSettings.BeforeSeenColor);
                });
                $('#' + parentId + ' .ikrNoti_Counter').fadeOut('slow');
                return false;
            });
            $(document).click(function () {
                $('#' + parentId + ' .ikrNotifications').hide();
                if ($('#' + parentId + ' .ikrNoti_Counter').is(':hidden')) {
                    //$('#' + parentId + ' .ikrNoti_Button').css('background-color', defaultSettings.AfterSeenColor);
                }
            });
            $('#' + parentId + ' .ikrNotifications').click(function () {
                return false;
            });

            $("#" + parentId).css({
                position: "relative"
            });
        }
    };
    $.fn.ikrNotificationCount = function (options) {
        /*
          Declaration : $("#myComboId").ikrNotificationCount({
                    NotificationList: [],
                    NotiFromPropName: "",
                    ListTitlePropName: "",
                    ListBodyPropName: "",
                    ControllerName: "Notifications",
                    ActionName: "AllNotifications"
          });
       */
        var defaultSettings = $.extend({
            NotificationList: [],
            NotiFromPropName: "",
            ListTitlePropName: "",
            ListBodyPropName: "",
            ControllerName: "Notification",
            ActionName: "AllNotifications"
        }, options);
        var parentId = $(this).attr("id");
        if ($.trim(parentId) != "" && parentId.length > 0) {
            $("#" + parentId + " .ikrNotifications .ikrSeeAll").click(function () {
                window.open('../' + defaultSettings.ControllerName + '/' + defaultSettings.ActionName + '', '_blank');
            });

            var totalUnReadNoti = defaultSettings.NotificationList.filter(x => x.isRead == false).length;
            $('#' + parentId + ' .ikrNoti_Counter').text(totalUnReadNoti);
            $('#' + parentId + ' .notiCounterOnHead').text(totalUnReadNoti);
            if (defaultSettings.NotificationList.length > 0) {
                $.map(defaultSettings.NotificationList, function (item) {
                    var className = item.isRead ? "" : " ikrSingleNotiDivUnReadColor";
                    var date = new Date(Date.parse(item.createDate));
                    var strDate = date.toGMTString();
                    var sNotiFromPropName = $.trim(defaultSettings.NotiFromPropName) == "" ? "" : item[ikrLowerFirstLetter(defaultSettings.NotiFromPropName)];
                    $("#" + parentId + " .ikrNotificationItems").append("<div style='padding-top: 10px' class='ikrSingleNotiDiv" + className + "' notiId=" + item.id + ">" +
                        //"<h4 class='ikrNotiFromPropName'><br/></h4>" +
                        "<img class='ikrNotificationBody' style='border-radius: 50%' width=70px height=80px src='/assets/img/artwork/logo.png' />" +
                        "<h6 class='ikrNotificationTitle'>" + item.header + "</h6>" +
                        "<div class='ikrNofiCreatedDate'><i>" +  timeAgo(strDate) + "</i></div>" +
                        "</div>");
                    $("#" + parentId + " .ikrNotificationItems .ikrSingleNotiDiv[notiId=" + item.id + "]").click(function () {
                        $.ajax({
                            type: 'POST',
                            url: '/notification/notiread',
                            data: {
                                notiId: item.id
                            }
                        })
                        if ($.trim(item.url) != "") {
                            window.location.href = item.url;
                        }
                    });
                });
            }
        }
    };
}(jQuery));

function ikrLowerFirstLetter(value) {
    return value.charAt(0).toLowerCase() + value.slice(1);
}
const MONTH_NAMES = [
    'January', 'February', 'March', 'April', 'May', 'June',
    'July', 'August', 'September', 'October', 'November', 'December'
];


function getFormattedDate(date, prefomattedDate = false, hideYear = false) {
    const day = date.getDate();
    const month = MONTH_NAMES[date.getMonth()];
    const year = date.getFullYear();
    const hours = date.getHours();
    let minutes = date.getMinutes();

    if (minutes < 10) {
        // Adding leading zero to minutes
        minutes = `0${minutes}`;
    }

    if (prefomattedDate) {
        // Today at 10:20
        // Yesterday at 10:20
        return `${prefomattedDate} at ${hours}:${minutes}`;
    }

    if (hideYear) {
        // 10. January at 10:20
        return `${day}. ${month} at ${hours}:${minutes}`;
    }

    // 10. January 2017. at 10:20
    return `${day}. ${month} ${year}. at ${hours}:${minutes}`;
}


// --- Main function
function timeAgo(dateParam) {
    if (!dateParam) {
        return null;
    }

    const date = typeof dateParam === 'object' ? dateParam : new Date(dateParam);
    const DAY_IN_MS = 86400000; // 24 * 60 * 60 * 1000
    const today = new Date();
    const yesterday = new Date(today - DAY_IN_MS);
    const seconds = Math.round((today - date) / 1000);
    const minutes = Math.round(seconds / 60);
    const isToday = today.toDateString() === date.toDateString();
    const isYesterday = yesterday.toDateString() === date.toDateString();
    const isThisYear = today.getFullYear() === date.getFullYear();


    if (seconds < 5) {
        return 'now';
    } else if (seconds < 60) {
        return `${seconds} seconds ago`;
    } else if (seconds < 90) {
        return 'about a minute ago';
    } else if (minutes < 60) {
        return `${minutes} minutes ago`;
    } else if (isToday) {
        return getFormattedDate(date, 'Today'); // Today at 10:20
    } else if (isYesterday) {
        return getFormattedDate(date, 'Yesterday'); // Yesterday at 10:20
    } else if (isThisYear) {
        return getFormattedDate(date, false, true); // 10. January at 10:20
    }

    return getFormattedDate(date); // 10. January 2017. at 10:20
}


