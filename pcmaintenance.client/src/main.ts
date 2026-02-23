import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

// La refresh să rămânem sus, nu restaura scroll-ul unde era utilizatorul
if ('scrollRestoration' in history) {
  history.scrollRestoration = 'manual'
}

const app = createApp(App)

app.use(router)

app.mount('#app')
