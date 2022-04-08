var path = require('path'),
    gulp = require('gulp'),
    rename = require('gulp-rename'),
    gp_clean = require('gulp-clean'),
    gp_sass = require('gulp-sass');

var basePath = path.resolve(__dirname, "wwwroot");

var srcPaths = {
    sass: [
        path.resolve(basePath, 'scss/blog-page.scss'),
        path.resolve(basePath, 'scss/users-page.scss'),
        path.resolve(basePath, 'scss/login-page.scss')
    ]
};

var destPaths = {
    css: path.resolve(basePath, 'css')
};

/* SASS/CSS */
gulp.task('sass_clean', function ()
{
    return gulp.src(destPaths.css + "*.*", { read: false })
        .pipe(gp_clean({ force: true }));
});

gulp.task('sass', function ()
{
    return gulp.src(srcPaths.sass)
        .pipe(gp_sass({ outputStyle: 'compressed' }))
        .pipe(rename({
            suffix: '.min'
        }))
        .pipe(gulp.dest(destPaths.css));
});

/* Defaults */
gulp.task('cleanup', gulp.series(['sass_clean']));

gulp.task('default', gulp.series(['sass']));


