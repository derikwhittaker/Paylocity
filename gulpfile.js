var gulp = require("gulp");
var jshint = require("gulp-jshint");

gulp.task('default', ['jshint'], function () { });

gulp.task('jshint', function () {
    return gulp.src("Paylocity.UI/application/**/*.js")
        .pipe(jshint())
        .pipe(jshint.reporter('default'))
        .pipe(jshint.reporter('fail'));
});