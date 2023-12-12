export default {
    // prefix: 'tw-',
    content: [
        "./index.html",
        "./src/**/*.{vue,js,ts,jsx,tsx}",
    ],
    theme: {
        extend: {
            colors: {
                bgColor: '#c2c6d0',
                bgColorDark: '#0f172a',
                textColor: '#000000',
                textSecondaryColor: '#718096',
                textColorDark: '#c2c6d0',
                borderColor: '#E2E8F0',
                borderColorDark: '#4A5568',
                successColor: '#48BB78',
                failedColor: '#F56565',
            }
        },
    },
    plugins: [],
}