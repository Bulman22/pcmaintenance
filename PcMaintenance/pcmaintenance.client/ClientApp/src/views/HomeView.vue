<template>
  <div>
    <!-- Hero Section -->
    <div class="relative bg-gradient-to-br from-blue-900 via-blue-800 to-indigo-900 overflow-hidden">
      <!-- Animated background elements -->
      <div class="absolute inset-0">
        <div class="absolute inset-0 bg-gradient-to-br from-blue-900/90 via-blue-800/90 to-indigo-900/90"></div>
        <div class="absolute top-0 left-0 w-full h-full">
          <div class="absolute top-20 left-10 w-72 h-72 bg-blue-500/20 rounded-full blur-3xl animate-pulse"></div>
          <div class="absolute bottom-20 right-10 w-96 h-96 bg-indigo-500/20 rounded-full blur-3xl animate-pulse delay-1000"></div>
          <div class="absolute top-1/2 left-1/2 transform -translate-x-1/2 -translate-y-1/2 w-80 h-80 bg-cyan-500/10 rounded-full blur-3xl animate-pulse delay-500"></div>
        </div>
      </div>
      
      <div class="relative max-w-7xl mx-auto py-16 px-4 sm:py-24 sm:px-6 lg:px-8">
        <div class="text-center">
          <div class="animate-fade-in-up">
            <h1 class="text-3xl font-black tracking-tight text-white sm:text-5xl md:text-6xl lg:text-7xl bg-gradient-to-r from-white via-blue-100 to-cyan-200 bg-clip-text text-transparent leading-tight">
             Service și Soluții IT Profesionale
            </h1>
            <p class="mt-6 max-w-4xl mx-auto text-lg sm:text-xl text-blue-100 leading-relaxed px-4">
              🚀 Servicii de reparații și mentenanță pentru calculatoare și laptopuri. 
             </p>
          </div>
          
          <div class="mt-8 sm:mt-12 flex flex-col sm:flex-row gap-3 sm:gap-4 justify-center items-center animate-fade-in-up delay-300 px-4">
            <button
              @click="scrollToServices"
              class="group inline-flex items-center justify-center px-6 py-3 sm:px-8 sm:py-4 border-2 border-white/30 text-base sm:text-lg font-semibold rounded-xl text-white bg-white/10 backdrop-blur-sm hover:bg-white hover:text-blue-900 focus:outline-none focus:ring-4 focus:ring-white/30 transition-all duration-300 transform hover:scale-105 hover:shadow-2xl w-full sm:w-auto"
            >
              <svg class="w-5 h-5 sm:w-6 sm:h-6 mr-2 sm:mr-3 group-hover:animate-bounce" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 9l-7 7-7-7" />
              </svg>
              Vezi serviciile
            </button>
            <button
              @click="scrollToContact"
              class="group inline-flex items-center justify-center px-6 py-3 sm:px-8 sm:py-4 border-2 border-green-400 text-base sm:text-lg font-semibold rounded-xl text-white bg-green-500/20 backdrop-blur-sm hover:bg-green-500 hover:text-white focus:outline-none focus:ring-4 focus:ring-green-400/30 transition-all duration-300 transform hover:scale-105 hover:shadow-2xl w-full sm:w-auto"
            >
              <svg class="w-5 h-5 sm:w-6 sm:h-6 mr-2 sm:mr-3 group-hover:animate-pulse" fill="currentColor" viewBox="0 0 24 24">
                <path d="M17.472 14.382c-.297-.149-1.758-.867-2.03-.967-.273-.099-.471-.148-.67.15-.197.297-.767.966-.94 1.164-.173.199-.347.223-.644.075-.297-.15-1.255-.463-2.39-1.475-.883-.788-1.48-1.761-1.653-2.059-.173-.297-.018-.458.13-.606.134-.133.298-.347.446-.52.149-.174.198-.298.298-.497.099-.198.05-.371-.025-.52-.075-.149-.669-1.612-.916-2.207-.242-.579-.487-.5-.669-.51-.173-.008-.371-.01-.57-.01-.198 0-.52.074-.792.372-.272.297-1.04 1.016-1.04 2.479 0 1.462 1.065 2.875 1.213 3.074.149.198 2.096 3.2 5.077 4.487.709.306 1.262.489 1.694.625.712.227 1.36.195 1.871.118.571-.085 1.758-.719 2.006-1.413.248-.694.248-1.289.173-1.413-.074-.124-.272-.198-.57-.347m-5.421 7.403h-.004a9.87 9.87 0 01-5.031-1.378l-.361-.214-3.741.982.998-3.648-.235-.374a9.86 9.86 0 01-1.51-5.26c.001-5.45 4.436-9.884 9.888-9.884 2.64 0 5.122 1.03 6.988 2.898a9.825 9.825 0 012.893 6.994c-.003 5.45-4.437 9.884-9.885 9.884m8.413-18.297A11.815 11.815 0 0012.05 0C5.495 0 .16 5.335.157 11.892c0 2.096.547 4.142 1.588 5.945L.057 24l6.305-1.654a11.882 11.882 0 005.683 1.448h.005c6.554 0 11.89-5.335 11.893-11.893A11.821 11.821 0 0020.885 3.488"/>
              </svg>
              Contact WhatsApp
            </button>
          </div>
        </div>
      </div>
    </div>

    <!-- Services Section -->
    <div id="services" class="py-24 bg-gradient-to-br from-gray-50 via-white to-blue-50">
      <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div class="text-center">
          <div class="inline-flex items-center justify-center w-16 h-16 bg-gradient-to-r from-blue-600 to-indigo-600 rounded-full mb-6">
            <svg class="w-8 h-8 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19.428 15.428a2 2 0 00-1.022-.547l-2.387-.477a6 6 0 00-3.86.517l-.318.158a6 6 0 01-3.86.517L6.05 15.21a2 2 0 00-1.806.547M8 4h8l-1 1v5.172a2 2 0 00.586 1.414l5 5c1.26 1.26.367 3.414-1.415 3.414H4.828c-1.782 0-2.674-2.154-1.414-3.414l5-5A2 2 0 009 10.172V5L8 4z" />
            </svg>
          </div>
          <h2 class="text-4xl font-black text-gray-900 sm:text-5xl bg-gradient-to-r from-gray-900 via-blue-800 to-indigo-800 bg-clip-text text-transparent">
            🛠️ Serviciile noastre
          </h2>
          <p class="mt-6 max-w-3xl mx-auto text-xl text-gray-600 leading-relaxed">
            ✨ Oferim servicii complete de diagnosticare, optimizare, mentenanță software și montaj standard de componente.
            <br class="hidden sm:block">
            🎯 Soluții personalizate pentru fiecare nevoie IT
          </p>
          <!-- Disclaimer clar pentru a nu induce în eroare clienții -->
          <div class="mt-4 max-w-3xl mx-auto">
            <div class="bg-yellow-50 border-l-4 border-yellow-400 text-yellow-700 p-3 rounded-md text-sm">
              Nu efectuăm reparații hardware complexe, lipituri sau schimb de ecran.
            </div>
          </div>
        </div>

        <div class="mt-20 grid grid-cols-1 gap-8 sm:grid-cols-2 lg:grid-cols-3">
          <!-- Mentenanță Laptop -->
          <div class="relative group transform hover:scale-105 transition-all duration-300">
            <div class="absolute -inset-1 bg-gradient-to-r from-blue-500 via-purple-500 to-pink-500 rounded-2xl blur opacity-30 group-hover:opacity-60 transition duration-1000 group-hover:duration-200"></div>
            <div class="relative bg-white rounded-2xl p-8 shadow-xl border border-gray-100 hover:shadow-2xl transition-all duration-300">
              <div class="w-16 h-16 bg-gradient-to-br from-blue-500 to-purple-600 rounded-2xl flex items-center justify-center mb-6 group-hover:rotate-12 transition-transform duration-300">
                <svg class="w-8 h-8 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9.75 17L9 20l-1 1h8l-1-1-.75-3M3 13h18M5 17h14a2 2 0 002-2V5a2 2 0 00-2-2H5a2 2 0 00-2 2v10a2 2 0 002 2z" />
                </svg>
              </div>
              <h3 class="text-2xl font-bold text-gray-900 mb-4 group-hover:text-blue-600 transition-colors duration-300">💻 Laptop</h3>
              <p class="text-gray-600 mb-6 leading-relaxed">
                🔧 Mentenanță completă pentru laptopuri
              </p>
              <ul class="text-sm text-gray-600 space-y-3">
                <li class="flex items-center"><span class="w-2 h-2 bg-blue-500 rounded-full mr-3"></span>🧹 Curățare software de viruși și fișiere inutile</li>
                <li class="flex items-center"><span class="w-2 h-2 bg-blue-500 rounded-full mr-3"></span>🔄 Instalare/actualizare drivere și programe</li>
                <li class="flex items-center"><span class="w-2 h-2 bg-blue-500 rounded-full mr-3"></span>⚡ Upgrade memorie și SSD</li>
                <li class="flex items-center"><span class="w-2 h-2 bg-blue-500 rounded-full mr-3"></span>⚡ Optimizare performanță Windows</li>
              </ul>
            </div>
          </div>

          <!-- Mentenanță Desktop -->
          <div class="relative group transform hover:scale-105 transition-all duration-300">
            <div class="absolute -inset-1 bg-gradient-to-r from-green-500 via-teal-500 to-cyan-500 rounded-2xl blur opacity-30 group-hover:opacity-60 transition duration-1000 group-hover:duration-200"></div>
            <div class="relative bg-white rounded-2xl p-8 shadow-xl border border-gray-100 hover:shadow-2xl transition-all duration-300">
              <div class="w-16 h-16 bg-gradient-to-br from-green-500 to-teal-600 rounded-2xl flex items-center justify-center mb-6 group-hover:rotate-12 transition-transform duration-300">
                <svg class="w-8 h-8 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9.75 17L9 20l-1 1h8l-1-1-.75-3M3 13h18M5 17h14a2 2 0 002-2V5a2 2 0 00-2-2H5a2 2 0 00-2 2v10a2 2 0 002 2z" />
                </svg>
              </div>
              <h3 class="text-2xl font-bold text-gray-900 mb-4 group-hover:text-green-600 transition-colors duration-300">🖥️ Desktop</h3>
              <p class="text-gray-600 mb-6 leading-relaxed">
                ⚙️ Servicii complete pentru calculatoare desktop
              </p>
              <ul class="text-sm text-gray-600 space-y-3">
                <li class="flex items-center"><span class="w-2 h-2 bg-green-500 rounded-full mr-3"></span>🔧 Asamblare PC personalizat</li>
                <li class="flex items-center"><span class="w-2 h-2 bg-green-500 rounded-full mr-3"></span>⬆️ Upgrade componente</li>
                <li class="flex items-center"><span class="w-2 h-2 bg-green-500 rounded-full mr-3"></span>🔄 Instalare și actualizare drivere, aplicații și sisteme de operare</li>
                <li class="flex items-center"><span class="w-2 h-2 bg-green-500 rounded-full mr-3"></span>🚀 Optimizare performanță</li>
              </ul>
            </div>
          </div>

          <!-- Network & Security -->
          <div class="relative group transform hover:scale-105 transition-all duration-300">
            <div class="absolute -inset-1 bg-gradient-to-r from-purple-500 via-pink-500 to-red-500 rounded-2xl blur opacity-30 group-hover:opacity-60 transition duration-1000 group-hover:duration-200"></div>
            <div class="relative bg-white rounded-2xl p-8 shadow-xl border border-gray-100 hover:shadow-2xl transition-all duration-300">
              <div class="w-16 h-16 bg-gradient-to-br from-purple-500 to-pink-600 rounded-2xl flex items-center justify-center mb-6 group-hover:rotate-12 transition-transform duration-300">
                <svg class="w-8 h-8 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 12l2 2 4-4m5.618-4.016A11.955 11.955 0 0112 2.944a11.955 11.955 0 01-8.618 3.04A12.02 12.02 0 003 9c0 5.591 3.824 10.29 9 11.622 5.176-1.332 9-6.03 9-11.622 0-1.042-.133-2.052-.382-3.016z" />
                </svg>
              </div>
              <h3 class="text-2xl font-bold text-gray-900 mb-4 group-hover:text-purple-600 transition-colors duration-300">🔒 Rețele & Securitate</h3>
              <p class="text-gray-600 mb-6 leading-relaxed">
                🛡️ Configurare rețele, securitate IT, protecție antivirus 
                și soluții pentru birou și casă.
              </p>
              <ul class="text-sm text-gray-600 space-y-3">
                <li class="flex items-center"><span class="w-2 h-2 bg-purple-500 rounded-full mr-3"></span>📶 Configurare rețele WiFi</li>
                <li class="flex items-center"><span class="w-2 h-2 bg-purple-500 rounded-full mr-3"></span>🔐 Securitate IT</li>
                <li class="flex items-center"><span class="w-2 h-2 bg-purple-500 rounded-full mr-3"></span>🛡️ Protecție antivirus</li>
                <li class="flex items-center"><span class="w-2 h-2 bg-purple-500 rounded-full mr-3"></span>🌐 Depanare conexiuni internet</li>
              </ul>
            </div>
          </div>

          <!-- Virtual Machines & SmartHome -->
          <div class="relative group transform hover:scale-105 transition-all duration-300">
            <div class="absolute -inset-1 bg-gradient-to-r from-cyan-500 via-blue-400 to-emerald-400 rounded-2xl blur opacity-30 group-hover:opacity-60 transition duration-1000 group-hover:duration-200"></div>
            <div class="relative bg-white rounded-2xl p-8 shadow-xl border border-gray-100 hover:shadow-2xl transition-all duration-300">
              <div class="w-16 h-16 bg-gradient-to-br from-cyan-500 to-emerald-600 rounded-2xl flex items-center justify-center mb-6 group-hover:rotate-12 transition-transform duration-300">
                <svg class="w-8 h-8 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 17V7a2 2 0 012-2h2a2 2 0 012 2v10m-6 0h6m-6 0a2 2 0 01-2-2V9a2 2 0 012-2m6 10a2 2 0 002-2V9a2 2 0 00-2-2" />
                </svg>
              </div>
              <h3 class="text-2xl font-bold text-gray-900 mb-4 group-hover:text-cyan-600 transition-colors duration-300">🖥️ Virtual Machines & 🏠 SmartHome</h3>
              <p class="text-gray-600 mb-6 leading-relaxed">
                ⚙️ Soluții integrate pentru virtualizare și automatizare locuință
              </p>
              <ul class="text-sm text-gray-600 space-y-3">
                <li class="flex items-center"><span class="w-2 h-2 bg-cyan-500 rounded-full mr-3"></span>🖥️ Configurare mașini virtuale (VMware, OracleVM, Proxmox)</li>
                <li class="flex items-center"><span class="w-2 h-2 bg-cyan-500 rounded-full mr-3"></span>📦 Deploy servere virtuale pentru testare și producție</li>
                <li class="flex items-center"><span class="w-2 h-2 bg-cyan-500 rounded-full mr-3"></span>🏠 Asistență configurare Smart Home (Home Assistant, IoT)</li>
                <li class="flex items-center"><span class="w-2 h-2 bg-cyan-500 rounded-full mr-3"></span>💡 Automatizări locuință și integrare dispozitive inteligente</li>
              </ul>
            </div>
          </div>
        </div>
      </div>
    </div>

    <!-- Why Choose Us Section -->
    <div class="py-24 bg-gradient-to-br from-blue-900 via-indigo-900 to-purple-900 relative overflow-hidden">
      <!-- Background elements -->
      <div class="absolute inset-0">
        <div class="absolute top-0 left-0 w-full h-full">
          <div class="absolute top-10 left-20 w-64 h-64 bg-blue-500/10 rounded-full blur-3xl animate-pulse"></div>
          <div class="absolute bottom-10 right-20 w-80 h-80 bg-purple-500/10 rounded-full blur-3xl animate-pulse delay-1000"></div>
          <div class="absolute top-1/2 left-1/2 transform -translate-x-1/2 -translate-y-1/2 w-72 h-72 bg-indigo-500/10 rounded-full blur-3xl animate-pulse delay-500"></div>
        </div>
      </div>
      
      <div class="relative max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div class="text-center">
          <div class="inline-flex items-center justify-center w-20 h-20 bg-gradient-to-r from-yellow-400 to-orange-500 rounded-full mb-8">
            <svg class="w-10 h-10 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z" />
            </svg>
          </div>
          <h2 class="text-4xl font-black text-white sm:text-5xl bg-gradient-to-r from-white via-yellow-200 to-orange-200 bg-clip-text text-transparent">
            ⭐ De ce să ne alegi?
          </h2>
          <p class="mt-6 max-w-3xl mx-auto text-xl text-blue-100 leading-relaxed">
            🏆 Suntem mândri să oferim servicii de cea mai bună calitate cu o experiență client excepțională
            <br class="hidden sm:block">
            💎 Garantăm satisfacția pentru fiecare client
          </p>
        </div>

        <div class="mt-20 grid grid-cols-1 gap-8 sm:grid-cols-2 lg:grid-cols-4">
          <div class="text-center group transform hover:scale-105 transition-all duration-300">
            <div class="w-20 h-20 bg-gradient-to-br from-green-400 to-emerald-600 rounded-full flex items-center justify-center mx-auto mb-6 group-hover:rotate-12 transition-transform duration-300 shadow-lg">
              <svg class="w-10 h-10 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 8v4l3 3m6-3a9 9 0 11-18 0 9 9 0 0118 0z" />
              </svg>
            </div>
            <h3 class="text-xl font-bold text-white mb-3 group-hover:text-green-300 transition-colors duration-300">⚡ Reparații Rapide</h3>
            <p class="text-blue-100 leading-relaxed">💨 Reparații rapide, fără așteptări inutile</p>
          </div>

          <div class="text-center group transform hover:scale-105 transition-all duration-300">
            <div class="w-20 h-20 bg-gradient-to-br from-blue-400 to-cyan-600 rounded-full flex items-center justify-center mx-auto mb-6 group-hover:rotate-12 transition-transform duration-300 shadow-lg">
              <svg class="w-10 h-10 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z" />
              </svg>
            </div>
            <h3 class="text-xl font-bold text-white mb-3 group-hover:text-blue-300 transition-colors duration-300">🛡️ Calitate Garantată</h3>
            <p class="text-blue-100 leading-relaxed">🛡️ Protecție și performanță garantată pentru PC-ul tău</p>
          </div>

          <div class="text-center group transform hover:scale-105 transition-all duration-300">
            <div class="w-20 h-20 bg-gradient-to-br from-yellow-400 to-orange-600 rounded-full flex items-center justify-center mx-auto mb-6 group-hover:rotate-12 transition-transform duration-300 shadow-lg">
              <svg class="w-10 h-10 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 8c-1.657 0-3 .895-3 2s1.343 2 3 2 3 .895 3 2-1.343 2-3 2m0-8c1.11 0 2.08.402 2.599 1M12 8V7m0 1v8m0 0v1m0-1c-1.11 0-2.08-.402-2.599-1" />
              </svg>
            </div>
            <h3 class="text-xl font-bold text-white mb-3 group-hover:text-yellow-300 transition-colors duration-300">💰 Prețuri Corecte</h3>
            <p class="text-blue-100 leading-relaxed">💎 Tarife transparente și competitive pe piață</p>
          </div>

          <!-- Motiv nou personalizat -->
          <div class="text-center group transform hover:scale-105 transition-all duration-300">
            <div class="w-20 h-20 bg-gradient-to-br from-purple-400 to-pink-600 rounded-full flex items-center justify-center mx-auto mb-6 group-hover:rotate-12 transition-transform duration-300 shadow-lg">
              <svg class="w-10 h-10 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M18 8a6 6 0 11-12 0 6 6 0 0112 0zm-6 8v4m0 0h4m-4 0H8" />
              </svg>
            </div>
            <h3 class="text-xl font-bold text-white mb-3 group-hover:text-pink-300 transition-colors duration-300">👨‍🔧 Direct cu specialistul</h3>
            <p class="text-blue-100 leading-relaxed">🛠️ Consultanță personalizată și experiență directă cu un profesionist.</p>
          </div>
        </div>
      </div>
    </div>

    <!-- CTA Section -->
    <div class="bg-gradient-to-r from-green-600 via-emerald-600 to-teal-600 relative overflow-hidden">
      <!-- Background elements -->
      <div class="absolute inset-0">
        <div class="absolute top-0 left-0 w-full h-full">
          <div class="absolute top-10 left-10 w-64 h-64 bg-white/10 rounded-full blur-3xl animate-pulse"></div>
          <div class="absolute bottom-10 right-10 w-80 h-80 bg-white/10 rounded-full blur-3xl animate-pulse delay-1000"></div>
        </div>
      </div>
      
      <div class="relative max-w-7xl mx-auto py-20 px-4 sm:py-28 sm:px-6 lg:px-8">
        <div class="text-center">
          <div class="inline-flex items-center justify-center w-20 h-20 bg-white/20 rounded-full mb-8">
            <svg class="w-10 h-10 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13 10V3L4 14h7v7l9-11h-7z" />
            </svg>
          </div>
          <h2 class="text-4xl font-black text-white sm:text-5xl bg-gradient-to-r from-white via-green-100 to-emerald-200 bg-clip-text text-transparent">
            🚀 Servicii profesionale de reparații PC
          </h2>
          <p class="mt-6 max-w-3xl mx-auto text-xl text-green-100 leading-relaxed">
            📞 Contactează-ne pentru orice problemă IT și vei primi un răspuns în cel mai scurt timp posibil
            <br class="hidden sm:block">
            ⚡ Răspundem în maximum 30 de minute!
          </p>
        </div>
      </div>
    </div>

    <!-- Contact Section -->
    <div id="contact" class="py-24 bg-gradient-to-br from-gray-50 via-white to-blue-50">
      <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div class="text-center">
          <div class="inline-flex items-center justify-center w-16 h-16 bg-gradient-to-r from-blue-600 to-indigo-600 rounded-full mb-6">
            <svg class="w-8 h-8 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 5a2 2 0 012-2h3.28a1 1 0 01.948.684l1.498 4.493a1 1 0 01-.502 1.21l-2.257 1.13a11.042 11.042 0 005.516 5.516l1.13-2.257a1 1 0 011.21-.502l4.493 1.498a1 1 0 01.684.949V19a2 2 0 01-2 2h-1C9.716 21 3 14.284 3 6V5z" />
            </svg>
          </div>
          <h2 class="text-4xl font-black text-gray-900 sm:text-5xl bg-gradient-to-r from-gray-900 via-blue-800 to-indigo-800 bg-clip-text text-transparent">
            📞 Contactează-ne
          </h2>
          <p class="mt-6 max-w-3xl mx-auto text-xl text-gray-600 leading-relaxed">
            🤝 Suntem aici să te ajutăm cu orice problemă IT
            <br class="hidden sm:block">
            💬 Contactează-ne acum pentru o consultație gratuită!
          </p>
        </div>

        <div class="mt-20 max-w-6xl mx-auto">
          <div class="bg-white rounded-3xl p-10 shadow-2xl border border-gray-100">
		<h3 class="text-2xl font-bold text-gray-900 mb-8 text-center">📋 Informații de contact</h3>
            <div class="grid grid-cols-1 lg:grid-cols-2 gap-8 lg:gap-10">
              <div class="space-y-4 sm:space-y-6">
                <div class="flex items-center group">
                  <div class="w-10 h-10 sm:w-12 sm:h-12 bg-gradient-to-br from-green-500 to-emerald-600 rounded-xl flex items-center justify-center mr-3 sm:mr-4 group-hover:rotate-12 transition-transform duration-300 flex-shrink-0">
                    <svg class="w-5 h-5 sm:w-6 sm:h-6 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 5a2 2 0 012-2h3.28a1 1 0 01.948.684l1.498 4.493a1 1 0 01-.502 1.21l-2.257 1.13a11.042 11.042 0 005.516 5.516l1.13-2.257a1 1 0 011.21-.502l4.493 1.498a1 1 0 01.684.949V19a2 2 0 01-2 2h-1C9.716 21 3 14.284 3 6V5z" />
                    </svg>
                  </div>
                  <div class="min-w-0">
                    <p class="text-xs sm:text-sm text-gray-500">📞 Telefon</p>
                    <p class="text-base sm:text-lg font-semibold text-gray-900 break-all">+40 723 132 854</p>
                  </div>
                </div>
                <div class="flex items-center group">
                  <div class="w-10 h-10 sm:w-12 sm:h-12 bg-gradient-to-br from-blue-500 to-cyan-600 rounded-xl flex items-center justify-center mr-3 sm:mr-4 group-hover:rotate-12 transition-transform duration-300 flex-shrink-0">
                    <svg class="w-5 h-5 sm:w-6 sm:h-6 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 8l7.89 4.26a2 2 0 002.22 0L21 8M5 19h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v10a2 2 0 002 2z" />
                    </svg>
                  </div>
                  <div class="min-w-0">
                    <p class="text-xs sm:text-sm text-gray-500">📧 Email</p>
                    <p class="text-base sm:text-lg font-semibold text-gray-900 break-all">contact@projecthomeboy.lol</p>
                  </div>
                </div>
                <div class="flex items-center group">
                  <div class="w-10 h-10 sm:w-12 sm:h-12 bg-gradient-to-br from-purple-500 to-pink-600 rounded-xl flex items-center justify-center mr-3 sm:mr-4 group-hover:rotate-12 transition-transform duration-300 flex-shrink-0">
                    <svg class="w-5 h-5 sm:w-6 sm:h-6 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M17.657 16.657L13.414 20.9a1.998 1.998 0 01-2.827 0l-4.244-4.243a8 8 0 1111.314 0z" />
                      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 11a3 3 0 11-6 0 3 3 0 016 0z" />
                    </svg>
                  </div>
                  <div class="min-w-0">
                    <p class="text-xs sm:text-sm text-gray-500">📍 Adresă</p>
                    <p class="text-base sm:text-lg font-semibold text-gray-900">Strada Drumul Gura Putnei 45C București</p>
                  </div>
                </div>
              </div>

              <div class="bg-gradient-to-br from-gray-50 to-blue-50 rounded-2xl p-4 sm:p-6">
                <h4 class="text-lg sm:text-xl font-bold text-gray-900 mb-4 sm:mb-6 flex items-center">
                  <svg class="w-5 h-5 sm:w-6 sm:h-6 text-blue-600 mr-2" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 8v4l3 3m6-3a9 9 0 11-18 0 9 9 0 0118 0z" />
                  </svg>
                  Program de lucru
                </h4>
                <div class="space-y-4 text-gray-700">
                  <div class="flex justify-between items-center py-2 border-b border-gray-200">
                    <span class="font-medium">Luni - Vineri:</span>
                    <span class="text-blue-600 font-semibold">09:00 - 18:00</span>
                  </div>
                  <div class="flex justify-between items-center py-2 border-b border-gray-200">
                    <span class="font-medium">Sâmbătă:</span>
                    <span class="text-blue-600 font-semibold">09:00 - 14:00</span>
                  </div>
                  <div class="flex justify-between items-center py-2">
                    <span class="font-medium">Duminică:</span>
                    <span class="text-red-500 font-semibold">Închis</span>
                  </div>
                </div>
              </div>
            </div>
            
            <!-- WhatsApp Button -->
            <div class="mt-8 sm:mt-12 flex justify-center">
              <a
                href="https://wa.me/40723132854?text=Bună! Am nevoie de o reparație PC."
                target="_blank"
                rel="noopener noreferrer"
                class="group inline-flex items-center justify-center px-6 py-4 sm:px-10 sm:py-5 bg-gradient-to-r from-green-500 to-emerald-600 hover:from-green-600 hover:to-emerald-700 text-white font-bold text-base sm:text-lg rounded-2xl transition-all duration-300 shadow-xl hover:shadow-2xl transform hover:scale-105 w-full sm:w-auto"
              >
                <svg class="w-6 h-6 sm:w-8 sm:h-8 mr-3 sm:mr-4 group-hover:animate-bounce" fill="currentColor" viewBox="0 0 24 24">
                  <path d="M17.472 14.382c-.297-.149-1.758-.867-2.03-.967-.273-.099-.471-.148-.67.15-.197.297-.767.966-.94 1.164-.173.199-.347.223-.644.075-.297-.15-1.255-.463-2.39-1.475-.883-.788-1.48-1.761-1.653-2.059-.173-.297-.018-.458.13-.606.134-.133.298-.347.446-.52.149-.174.198-.298.298-.497.099-.198.05-.371-.025-.52-.075-.149-.669-1.612-.916-2.207-.242-.579-.487-.5-.669-.51-.173-.008-.371-.01-.57-.01-.198 0-.52.074-.792.372-.272.297-1.04 1.016-1.04 2.479 0 1.462 1.065 2.875 1.213 3.074.149.198 2.096 3.2 5.077 4.487.709.306 1.262.489 1.694.625.712.227 1.36.195 1.871.118.571-.085 1.758-.719 2.006-1.413.248-.694.248-1.289.173-1.413-.074-.124-.272-.198-.57-.347m-5.421 7.403h-.004a9.87 9.87 0 01-5.031-1.378l-.361-.214-3.741.982.998-3.648-.235-.374a9.86 9.86 0 01-1.51-5.26c.001-5.45 4.436-9.884 9.888-9.884 2.64 0 5.122 1.03 6.988 2.898a9.825 9.825 0 012.893 6.994c-.003 5.45-4.437 9.884-9.885 9.884m8.413-18.297A11.815 11.815 0 0012.05 0C5.495 0 .16 5.335.157 11.892c0 2.096.547 4.142 1.588 5.945L.057 24l6.305-1.654a11.882 11.882 0 005.683 1.448h.005c6.554 0 11.89-5.335 11.893-11.893A11.821 11.821 0 0020.885 3.488"/>
                </svg>
                💬 Contactează-ne pe WhatsApp
              </a>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { onMounted } from 'vue'
import { useRoute } from 'vue-router'

const route = useRoute()

const scrollToServices = () => {
  document.getElementById('services')?.scrollIntoView({ behavior: 'smooth' })
}

const scrollToContact = () => {
  document.getElementById('contact')?.scrollIntoView({ behavior: 'smooth' })
}

onMounted(() => {
  // Dacă URL-ul conține un hash, scroll la secțiunea respectivă
  if (route.hash) {
    setTimeout(() => {
      const element = document.getElementById(route.hash.substring(1))
      if (element) {
        element.scrollIntoView({ behavior: 'smooth' })
      }
    }, 100)
  }
})
</script>
