# PC Maintenance Website

Un site web modern pentru servicii de reparații PC, construit cu Vue.js 3 și Tailwind CSS.

## 🚀 Caracteristici

- **Design modern** cu Tailwind CSS
- **Responsive** - funcționează pe toate dispozitivele
- **Optimizat pentru SEO** cu meta tag-uri
- **Performanță înaltă** cu nginx
- **Containerizat** cu Docker
- **Ușor de hostat** pe orice server Linux

## 🛠️ Tehnologii

- **Frontend**: Vue.js 3, TypeScript, Tailwind CSS
- **Build**: Vite
- **Server**: Nginx
- **Containerizare**: Docker, Docker Compose

## 📦 Instalare și Rulare

### Opțiunea 1: Cu Docker (Recomandat)

1. **Clonează repository-ul:**
   ```bash
   git clone <repository-url>
   cd PcMaintenance
   ```

2. **Rulează cu Docker Compose:**
   ```bash
   docker-compose up --build -d
   ```

3. **Accesează site-ul:**
   - Deschide browserul la `http://localhost`

### Opțiunea 2: Deployment automat

1. **Rulează scriptul de deployment:**
   ```bash
   chmod +x deploy.sh
   ./deploy.sh
   ```

### Opțiunea 3: Dezvoltare locală

1. **Instalează dependențele:**
   ```bash
   cd pcmaintenance.client
   npm install
   ```

2. **Rulează serverul de dezvoltare:**
   ```bash
   npm run dev
   ```

3. **Accesează site-ul:**
   - Deschide browserul la `https://localhost:61232`

## 🐳 Docker

### Comenzi utile

```bash
# Construiește imaginea
docker build -t pcmaintenance-web .

# Rulează containerul
docker run -p 80:80 pcmaintenance-web

# Vezi logurile
docker-compose logs -f

# Oprește containerele
docker-compose down

# Reconstruiește și repornește
docker-compose up --build -d
```

## 🌐 Hosting

Site-ul este optimizat pentru hosting pe servere Linux cu Docker. Poate fi hostat pe:

- **VPS** (DigitalOcean, Linode, Vultr)
- **Cloud** (AWS, Google Cloud, Azure)
- **Dedicated servers**
- **Shared hosting** cu suport Docker

### Configurare pentru producție

1. **Actualizează `nginx.conf`** pentru domeniul tău
2. **Configurează SSL** cu Let's Encrypt
3. **Set up monitoring** cu Docker logs
4. **Configurează backup** pentru container

## 📁 Structura proiectului

```
PcMaintenance/
├── pcmaintenance.client/     # Frontend Vue.js
│   ├── src/
│   │   ├── components/       # Componente Vue
│   │   ├── views/           # Pagini
│   │   └── assets/          # CSS, imagini
│   ├── package.json
│   └── vite.config.ts
├── Dockerfile               # Configurație Docker
├── docker-compose.yml      # Orchestrare containere
├── nginx.conf              # Configurație Nginx
└── deploy.sh               # Script deployment
```

## 🔧 Configurare

### Variabile de mediu

- `NODE_ENV=production` - Mediu de producție
- `PORT=80` - Portul serverului

### Personalizare

1. **Culori**: Editează `tailwind.config.js`
2. **Conținut**: Modifică `src/views/HomeView.vue`
3. **Logo**: Înlocuiește `src/assets/logo.svg`
4. **Contact**: Actualizează informațiile din header și footer

## 📞 Contact

Pentru suport tehnic sau întrebări despre implementare, contactează-ne:

- **WhatsApp**: +40 723 132 854
- **Email**: contact@pcmaintenance.ro

## 📄 Licență

Acest proiect este licențiat sub MIT License.