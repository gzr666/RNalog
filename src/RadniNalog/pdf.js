module.exports = function (callback, zaposlenici) {
    var jsreport = require('jsreport-core')();
    var jsrender = require('jsrender');
    //var handlebars = require("handlebars");

    var tmpl = jsrender.templates('./pdf/pdf.html');

    jsreport.init().then(function () {
        return jsreport.render({
            template: {

                content: tmpl.render({ zaps: zaposlenici }),
                engine: 'jsrender',
                recipe: 'phantom-pdf'
            },
            //data: {
            //    foo: test
            //}
        }).then(function (resp) {
            callback(/* error */ null, resp.content.toJSON().data);
        });
    }).catch(function (e) {
        callback(/* error */ e, null);
    })
};