module.exports = function (grunt) {
    grunt.initConfig({
        clean: ["wwwroot/lib/*", "temp/"],
        concat: {
            all: {
                src: ['TypeScript/Tastes.js', 'TypeScript/Food.js'],
                dest: 'temp/combined.js'
            }
        },
        jshint: {
            files: ['temp/*.js'],
            options: {
                '-W069': false,
            }
        },
        uglify: {
            all: {
                src: ['temp/combined.js'],
                dest: 'wwwroot/lib/combined.min.js'
            }
        },
        watch: {
            compass: {
                files: [
                    'app/styles/**/*.{css,scss,sass}'
                ],
                tasks: 'compass reload'
            },

        }
    });
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.registerTask('dev', 'watch');
};