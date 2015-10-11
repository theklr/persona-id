sabio.services.accounts = {};



sabio.services.accounts.get = function (onSuccess, onError) {
    var circuit = '/api/user/';
    var settings = {
        dataType: 'JSON',
        type: 'get',
        data: null,
    };
    var call = $.ajax(circuit, settings);
    call.done(onSuccess);
    call.fail(onError);
}