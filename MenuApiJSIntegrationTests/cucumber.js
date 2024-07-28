import 'dotenv/config'

export default {
    parallel: 2,
    format: ['html:cucumber-report.html'],
    import: ['./features/step_definitions/**/*.js', './features/support/**/*.js']
}