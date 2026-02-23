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

### Opțiunea 2: Dezvoltare locală (API + Vue împreună)

1. **Din rădăcina proiectului** instalează dependențele și pornește backend + frontend:
   ```bash
   npm install
   cd pcmaintenance.client && npm install && cd ..
   npm run dev
   ```
   Aceasta pornește API-ul .NET pe `http://localhost:55001` și Vue (Vite) pe `http://localhost:61232`, cu proxy pentru `/api` către backend.

2. **Accesează site-ul:**
   - Deschide browserul la `http://localhost:61232` (sau portul afișat de Vite).

**Doar frontend** (dacă API-ul rulează deja):
   ```bash
   cd pcmaintenance.client && npm run dev
   ```

**Doar backend:**
   ```bash
   cd PcMaintenance.Server && dotnet run --urls http://localhost:55001
   ```

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
├── PcMaintenance.Server/    # Backend ASP.NET Core (API, EF, migrații)
│   ├── Controllers/         # ex. ReviewsController
│   ├── Data/                # AppDbContext, entități
│   └── Migrations/
├── pcmaintenance.client/    # Frontend Vue.js (doar SPA)
│   ├── src/
│   │   ├── components/
│   │   ├── views/
│   │   └── assets/
│   ├── package.json
│   └── vite.config.ts
├── Dockerfile
├── docker-compose.yml
└── nginx.conf
```

## 🔧 Configurare

### Migrări EF Core la deploy

- Folosim **EF Core Migrations** pentru PostgreSQL. Migrările se aplică la **pornirea aplicației**, în `Program.cs`, cu `context.Database.Migrate()` (nu `EnsureCreated()`).
- **Înainte de deploy:** rulează local când schimbi modelul:
  ```bash
  dotnet ef migrations add NumeMigrare --project PcMaintenance.Server
  ```
  Nu adăuga migrări direct în pipeline.
- **La deploy:** nu e nevoie de pas separat; aplicația aplică migrările singură la startup. Asigură-te că doar o instanță pornește primul (sau că `Migrate()` e idempotent).
- Connection string-ul pentru DB vine mereu din configurare (env / secrets), niciodată hardcodat în cod.

### Conexiune la baza de date (PostgreSQL)

Deploy-ul se face prin workflow-ul GitHub Actions (push pe `main` sau trigger manual). Connection string-ul se setează ca secret **DB_CONNECTION_STRING** în GitHub (Settings → Secrets and variables → Actions) și este injectat în container via `.env` (creat în workflow). Pentru Docker Hub: **DOCKERHUB_USERNAME** și **DOCKERHUB_TOKEN**.

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