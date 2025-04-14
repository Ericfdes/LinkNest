/** @type {import('tailwindcss').Config} */
export default {
  content: [

    './src/**/*.{js,ts,jsx,tsx}', // ✅ YOUR components, pages, layouts etc.
    'node_modules/daisyui/dist/**/*.js',
    'node_modules/react-daisyui/dist/**/*.js',
  ],
  theme: {
    extend: {},
  },
  plugins: [require('daisyui')],
  daisyui: {
    themes: ['light', 'black'],
  }
}

