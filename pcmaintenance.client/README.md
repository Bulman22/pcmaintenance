# pcmaintenance.client

Vue 3 + Vite frontend and ASP.NET Core backend in one project. Single folder: run `dotnet run` for API + SPA proxy, or `npm run dev` for frontend only.

## Folder structure

```
src/
├── api/              # HTTP client and backend endpoints
├── assets/           # Static assets (CSS, images in assets/images/)
├── components/
│   ├── layout/       # App shell: AppLayout, AppHeader
│   └── <feature>/    # Feature-specific components (e.g. home/)
├── composables/      # Reusable composition functions
├── router/           # Vue Router config
├── stores/           # Pinia (or other) state stores
├── types/            # Shared TypeScript types
├── views/            # One view per route
├── App.vue
└── main.ts
```

**Conventions:**

- **views/** — One page per route; use for top-level route components.
- **components/layout/** — Layout components only (AppLayout, AppHeader).
- **components/\<feature\>/** — Components grouped by feature/domain (e.g. `home/` for Home-specific pieces).
- **api/** — All HTTP and backend API calls.
- **stores/** — App-wide state (e.g. Pinia).
- **composables/** — Reusable logic shared between components.
- **types/** — Shared TypeScript interfaces and types.

Use the `@` alias for imports (e.g. `@/components/layout/AppLayout.vue`, `@/composables/useScrollToSection`).

## Recommended IDE Setup

[VSCode](https://code.visualstudio.com/) + [Volar](https://marketplace.visualstudio.com/items?itemName=Vue.volar) (and disable Vetur).

## Type Support for `.vue` Imports in TS

TypeScript cannot handle type information for `.vue` imports by default, so we replace the `tsc` CLI with `vue-tsc` for type checking. In editors, we need [Volar](https://marketplace.visualstudio.com/items?itemName=Vue.volar) to make the TypeScript language service aware of `.vue` types.

## Customize configuration

See [Vite Configuration Reference](https://vite.dev/config/).

## Project Setup

**Requirements:** Node.js (>=20), .NET 8, PostgreSQL (for reviews API).

```sh
npm install
```

### Run backend (API + SPA proxy in Development)

From project root:

```sh
dotnet run
```

In Development this starts the API and proxies browser requests to the Vite dev server (port 61232). Open https://localhost:55000 (or the URL from launchSettings). Start the Vite dev server separately in another terminal with `npm run dev` so the proxy has something to connect to.

### Run frontend only (Vite dev server)

From project root:

```sh
npm run dev
```

Runs Vite; API calls go to `/api` (configure proxy in vite.config.ts if needed when not using dotnet run).

### Database (PostgreSQL)

Connection string is in `appsettings.json` / `appsettings.Development.json`. Apply migrations (requires `dotnet ef` tool: `dotnet tool install -g dotnet-ef`):

```sh
dotnet ef database update
```

### Type-Check, Compile and Minify for Production

```sh
npm run build
```

### Lint with [ESLint](https://eslint.org/)

```sh
npm run lint
```
