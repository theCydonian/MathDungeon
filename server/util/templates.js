let path = require('path');
let fs = require('fs');
let handlebars = require('handlebars');

module.exports.get = function getTemplate(relativeName) {
    return handlebars.compile(
        fs.readFileSync(
            path.join(
                __dirname,
                '..',
                relativeName,
            ),
            'utf-8',
        ),
    );
};