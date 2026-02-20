# Build stage
FROM node:20-alpine as build

WORKDIR /app

# Copy package files
COPY pcmaintenance.client/ClientApp/package*.json ./

# Clean install dependencies (including dev dependencies for build)
RUN rm -rf node_modules package-lock.json && \
    npm install --legacy-peer-deps && \
    npm rebuild esbuild

# Copy source code
COPY pcmaintenance.client/ClientApp/ ./

# Build the application
RUN npm run build

# Production stage
FROM nginx:alpine

# Copy built files from build stage
COPY --from=build /app/dist /usr/share/nginx/html

# Copy nginx configuration
COPY nginx.conf /etc/nginx/nginx.conf

# Expose port 80
EXPOSE 80

# Start nginx
CMD ["nginx", "-g", "daemon off;"]

