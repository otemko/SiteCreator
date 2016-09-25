var ts = require('gulp-typescript');
var gulp = require('gulp');
var clean = require('gulp-clean');

var destPath = './wwwroot/libs/';

gulp.task('clean', function() {
    return gulp.src(destPath)
        .pipe(clean());
});

gulp.task("scriptsNStyles", () => {
    gulp.src([
            'core-js/client/**',
            'systemjs/dist/system.src.js',
            'reflect-metadata/**',
            'rxjs/**',
            'zone.js/dist/**',
            '@angular/**',
            'jquery/dist/**',
            'jquery-validation/dist/**',
            'jquery-validation-unobtrusive/**',
            'bootstrap/dist/**',
            'font-awesome/**'

        ], {
            cwd: "node_modules/**"
        })
        .pipe(gulp.dest("./wwwroot/lib"));
});

var tsProject = ts.createProject('Scripts/tsconfig.json');

gulp.task('ts', function(done) {
    //var tsResult = tsProject.src()
    var tsResult = gulp.src([
            "Scripts/**/*.ts"
        ])
        .pipe(ts(tsProject), undefined, ts.reporter.fullReporter());
    return tsResult.js.pipe(gulp.dest('./wwwroot/appScripts'));
});

gulp.task("html", () => {
    gulp.src([
            'Scripts/**/*.html',
            'Scripts/**/*.css'
        ])
        .pipe(gulp.dest("./wwwroot/appScripts/"))
})

gulp.task('watch', ['watch.ts']);

gulp.task('watch.ts', ['ts', 'html'], function() {
    return gulp.watch('Scripts/**', ['ts', 'html']);
});

gulp.task('default', ['scriptsNStyles', 'watch']);