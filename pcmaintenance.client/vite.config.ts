import { fileURLToPath, URL } from 'node:url';

import { defineConfig } from 'vite';
import plugin from '@vitejs/plugin-vue';
import { env } from 'process';

// https://vitejs.dev/config/
export default defineConfig({
    plugins: [plugin()],
    css: {
        postcss: './postcss.config.js',
    },
    resolve: {
        alias: {
            '@': fileURLToPath(new URL('./src', import.meta.url))
        }
    },
    server: {
        port: parseInt(env.DEV_SERVER_PORT || '61232'),
        host: true,
        proxy: {
            '/api': {
                target: 'http://localhost:55001',
                changeOrigin: true
            }
        }
    },
    build: {
        outDir: 'dist',
        sourcemap: false,
        minify: 'terser'
    }
})
