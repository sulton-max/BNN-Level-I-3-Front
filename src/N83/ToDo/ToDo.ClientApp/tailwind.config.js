export default {
    content: [
        "./index.html",
        "./src/**/*.{vue,js,ts,jsx,tsx}",
    ],
    theme: {
        extend: {
            colors: {
                bgColor: '#FFFFFF',
                bgColorDark: '#0f172a',
                textColor: '#000000',
                textColorDark: '#FFFFFF',
                borderColor: '#E2E8F0',
                borderColorDark: '#4A5568',
                successColor: '#48BB78',
                failedColor: '#F56565',
            }
        },
    },
    plugins: [],
}