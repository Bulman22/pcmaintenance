#!/bin/bash

# PC Maintenance Website Deployment Script

echo "🚀 Starting PC Maintenance website deployment..."

# Check if Docker is installed
if ! command -v docker &> /dev/null; then
    echo "❌ Docker is not installed. Please install Docker first."
    exit 1
fi

# Check if Docker Compose is installed
if ! command -v docker-compose &> /dev/null; then
    echo "❌ Docker Compose is not installed. Please install Docker Compose first."
    exit 1
fi

# Stop existing containers
echo "🛑 Stopping existing containers..."
docker-compose down

# Remove old images
echo "🗑️  Removing old images..."
docker image prune -f

# Build and start containers
echo "🔨 Building and starting containers..."
docker-compose up --build -d

# Check if containers are running
echo "✅ Checking container status..."
if docker-compose ps | grep -q "Up"; then
    echo "🎉 Deployment successful!"
    echo "🌐 Website is available at: http://localhost"
    echo "📊 Container status:"
    docker-compose ps
else
    echo "❌ Deployment failed. Check logs with: docker-compose logs"
    exit 1
fi

echo "✨ Deployment completed!"
