var gulp = require('gulp');
var sass = require('gulp-sass');
var autoprefixer = require('gulp-autoprefixer');
var cssnano = require('gulp-cssnano');
var rename = require('gulp-rename');

var sassPaths = [
  'scss/**/*.scss',
  'node_modules/foundation-sites/scss'
];

var sassWatch = [
  'scss/**/*.scss',
  'node_modules/foundation-sites/scss/**/*.scss'
];

var css_destPath = '../Umbraco.Site/css';
        
gulp.task('sass', function () {
  return gulp.src('scss/app.scss')
      .pipe(sass({
        includePaths: sassPaths,
        errLogToConsole: true
      })
      .on('error', sass.logError))
      .pipe(autoprefixer({
        browsers: ['> 1%', 'last 2 versions', 'ie >= 9']
      }))
      .pipe(gulp.dest(css_destPath))
      .pipe(cssnano())
      .pipe(rename({ extname: '.min.css' }))
      .pipe(gulp.dest(css_destPath));
});

gulp.task('default', ['sass'], function () {
  gulp.watch(sassWatch, ['sass']);
});
