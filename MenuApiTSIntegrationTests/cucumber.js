require('dotenv').config()
// console.log(process.env) // remove this after you've confirmed it is working

let common = [
    'features/**/*.feature',
    '--require ./features/stepDefinitions/**/*.ts',
    '--require ./dist/**/*.js',
    '--format progress-bar',
    `--format-options '{"snippetInterface": "synchronous"}'`
].join(' ');


module.exports = {
    default: common
}