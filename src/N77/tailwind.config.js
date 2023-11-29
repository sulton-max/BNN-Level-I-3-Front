export default {
    content: [
        "./index.html",
        "./src/**/*.{vue,js,ts,jsx,tsx}",
    ],
    theme: {
        screens: {
            sm: '545px',
            md: '960px',
            lg: '1280px',
        },
        extend: {
            colors: {
                textPrimary: '#222222',
                textSecondary: '#818181',
                logoSelected: '#000000',
                logoSecondary: '#717171',
                logoAccent: '#dddddd',
                logoPrimary: '#ff385c',
                borderSecondary: '#cccccc',
            }
        },
    },
    plugins: [],
}