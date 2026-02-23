<template>
  <section class="py-24 bg-gradient-to-br from-gray-50 via-white to-blue-50">
    <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
      <div class="text-center mb-12">
        <h2 class="text-4xl font-black text-gray-900 sm:text-5xl bg-gradient-to-r from-gray-900 via-blue-800 to-indigo-800 bg-clip-text text-transparent">
          Ce spun clienții
        </h2>
        <p class="mt-4 text-xl text-gray-600 max-w-2xl mx-auto">
          Recenzii de la cei care ne-au ales pentru serviciile IT
        </p>
      </div>

      <div v-if="loading" class="text-center py-12 text-gray-500">
        Se încarcă recenziile...
      </div>
      <div v-else-if="reviews.length === 0" class="text-center py-12 text-gray-500">
        Încă nu există recenzii. Fii primul care lasă o recenzie!
      </div>
      <div v-else class="relative overflow-hidden">
        <div
          ref="scrollRef"
          class="flex gap-6 overflow-x-auto pb-4 scrollbar-hide carousel-track"
          :class="{ 'carousel-paused': isPaused }"
          style="scrollbar-width: none; -ms-overflow-style: none;"
          @mouseenter="pauseAutoPlay"
          @mouseleave="resumeAutoPlay"
        >
          <template v-for="(review, idx) in displayReviews" :key="`${review.id}-${idx}`">
            <div class="flex-shrink-0 w-[min(100%,320px)] sm:w-96 review-card">
              <div class="bg-white rounded-2xl p-6 shadow-lg border border-gray-100 h-full flex flex-col">
                <div class="flex items-center gap-1 mb-3">
                  <span
                    v-for="star in 5"
                    :key="star"
                    class="text-amber-400"
                    :class="star <= review.rating ? 'opacity-100' : 'opacity-30'"
                  >
                    ★
                  </span>
                </div>
                <p class="text-gray-700 flex-1">{{ review.comment }}</p>
                <p class="mt-4 font-semibold text-gray-900">{{ review.authorName }}</p>
                <p class="text-sm text-gray-500">{{ formatDate(review.createdAt) }}</p>
              </div>
            </div>
          </template>
        </div>
        <button
          v-if="reviews.length > 1"
          type="button"
          class="absolute left-0 top-1/2 -translate-y-1/2 -translate-x-2 w-10 h-10 rounded-full bg-white shadow-lg border border-gray-200 flex items-center justify-center text-gray-600 hover:bg-gray-50 z-10"
          aria-label="Anterior"
          @click="scroll(-1)"
        >
          ‹
        </button>
        <button
          v-if="reviews.length > 1"
          type="button"
          class="absolute right-0 top-1/2 -translate-y-1/2 translate-x-2 w-10 h-10 rounded-full bg-white shadow-lg border border-gray-200 flex items-center justify-center text-gray-600 hover:bg-gray-50 z-10"
          aria-label="Următor"
          @click="scroll(1)"
        >
          ›
        </button>
      </div>
    </div>
  </section>
</template>

<script setup lang="ts">
import { ref, computed, onMounted, onUnmounted, watch } from 'vue'
import { getReviews } from '@/api/reviews'
import type { Review } from '@/types/review'

const CARD_WIDTH = 320
const GAP = 24
const CARD_WIDTH_PLUS_GAP = CARD_WIDTH + GAP
/** Scroll speed: px per second (slow pace) */
const SCROLL_SPEED_PX_PER_S = 24

const props = defineProps<{ refresh?: number }>()
watch(() => props.refresh, () => load(), { flush: 'post' })

const reviews = ref<Review[]>([])
const loading = ref(true)
const scrollRef = ref<HTMLElement | null>(null)
const isPaused = ref(false)
/** Duplicate reviews so we can loop seamlessly (3 copies for long enough track) */
const displayReviews = computed(() => {
  const list = reviews.value
  if (list.length === 0) return []
  return [...list, ...list, ...list]
})

let animationFrameId: number | null = null
let lastScrollTime = 0

function formatDate(iso: string): string {
  try {
    return new Date(iso).toLocaleDateString('ro-RO', {
      day: 'numeric',
      month: 'short',
      year: 'numeric'
    })
  } catch {
    return iso
  }
}

function scroll(direction: number) {
  const el = scrollRef.value
  if (!el) return
  el.scrollBy({ left: direction * CARD_WIDTH_PLUS_GAP, behavior: 'smooth' })
}

function tick(timestamp: number) {
  const el = scrollRef.value
  if (!el || isPaused.value || reviews.value.length <= 1) {
    animationFrameId = requestAnimationFrame(tick)
    return
  }
  const dt = lastScrollTime ? (timestamp - lastScrollTime) / 1000 : 0
  lastScrollTime = timestamp
  const oneSetWidth = reviews.value.length * CARD_WIDTH_PLUS_GAP
  el.scrollLeft += SCROLL_SPEED_PX_PER_S * dt
  if (el.scrollLeft >= oneSetWidth) {
    el.scrollLeft -= oneSetWidth
  }
  animationFrameId = requestAnimationFrame(tick)
}

function startAutoPlay() {
  if (reviews.value.length <= 1) return
  lastScrollTime = 0
  if (!animationFrameId) {
    animationFrameId = requestAnimationFrame(tick)
  }
}

function pauseAutoPlay() {
  isPaused.value = true
}

function resumeAutoPlay() {
  isPaused.value = false
  if (reviews.value.length > 1 && animationFrameId === null) {
    startAutoPlay()
  }
}

async function load() {
  loading.value = true
  if (animationFrameId !== null) {
    cancelAnimationFrame(animationFrameId)
    animationFrameId = null
  }
  try {
    reviews.value = await getReviews()
  } catch {
    reviews.value = []
  } finally {
    loading.value = false
    if (reviews.value.length > 1) {
      startAutoPlay()
    }
  }
}

onMounted(load)
onUnmounted(() => {
  if (animationFrameId !== null) {
    cancelAnimationFrame(animationFrameId)
    animationFrameId = null
  }
})
</script>

<style scoped>
.scrollbar-hide::-webkit-scrollbar {
  display: none;
}
</style>
