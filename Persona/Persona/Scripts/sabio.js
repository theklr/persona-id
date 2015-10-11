
var sabio = {
    layout: {
        handlers: {}
    }
    , page: {
        handlers: {}
        , startUp: null
    }
    , services: {}
    , app: { profiles: {} }
};

sabio.layout.startUp = function () {

    console.debug("sabio.layout.startUp");

    $('#logout').on('click', sabio.layout.handlers.logout);

    if (typeof Metronic != "undefined" && typeof Layout != "undefined")
        //if (Metronic && Layout)
    {
        Metronic.init(); // init metronic core components
        Layout.init(); // init current layout

        if (typeof Demo != "undefined") {
            Demo.init(); // init demo features
        }
    }


    //this does a null check on sabio.page.startUp
    if (sabio.page.startUp) {
        console.debug("sabio.page.startUp");
        sabio.page.startUp();

    }
};
$(document).ready(sabio.layout.startUp);