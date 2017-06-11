module.exports = function (callback, rnalog) {
    var jsreport = require('jsreport-core')();
    var jsrender = require('jsrender');
    //var handlebars = require("handlebars");

    var tmpl = jsrender.templates('./pdf/pdfSingle.html');

    jsreport.init().then(function () {
        return jsreport.render({
            template: {

                content: tmpl.render({ nalog: rnalog }),
                engine: 'jsrender',
                recipe: 'phantom-pdf',
                phantom:
                {
                    orientation: "portrait",
                    format: "A4",
                    footer: "<div style='text-align:center'>{#pageNum}/{#numPages}</div>"

                }
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