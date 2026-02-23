<template>
  <div class="mt-10 bg-white rounded-2xl p-6 sm:p-8 shadow-xl border border-gray-100">
    <h3 class="text-2xl font-bold text-gray-900 mb-6 text-center">Lasă-ne o recenzie</h3>
    <form @submit.prevent="submit" class="space-y-4 max-w-xl mx-auto">
      <!-- Honeypot: hidden from users; bots fill it -> we do not submit -->
      <div
        class="absolute -left-[9999px] w-px h-px overflow-hidden opacity-0"
        aria-hidden="true"
      >
        <label for="website">Site (nu completați)</label>
        <input
          id="website"
          v-model="form.website"
          type="text"
          name="website"
          autocomplete="off"
          tabindex="-1"
        />
      </div>
      <div>
        <label for="authorName" class="block text-sm font-medium text-gray-700 mb-1">Nume</label>
        <input
          id="authorName"
          v-model="form.authorName"
          type="text"
          required
          maxlength="200"
          class="w-full rounded-lg border border-gray-300 px-4 py-2 focus:ring-2 focus:ring-blue-500 focus:border-blue-500"
          placeholder="Numele tău"
        />
      </div>
      <div>
        <label class="block text-sm font-medium text-gray-700 mb-2">Rating (1–5 stele)</label>
        <div class="flex gap-2">
          <button
            v-for="n in 5"
            :key="n"
            type="button"
            class="text-2xl focus:outline-none transition-transform hover:scale-110"
            :class="form.rating >= n ? 'text-amber-400' : 'text-gray-300'"
            :aria-label="`${n} stele`"
            @click="form.rating = n"
          >
            ★
          </button>
        </div>
      </div>
      <div>
        <label for="comment" class="block text-sm font-medium text-gray-700 mb-1">Comentariu</label>
        <textarea
          id="comment"
          v-model="form.comment"
          required
          maxlength="2000"
          rows="4"
          class="w-full rounded-lg border border-gray-300 px-4 py-2 focus:ring-2 focus:ring-blue-500 focus:border-blue-500"
          placeholder="Spune-ne ce părere ai despre serviciile noastre..."
        />
        <p class="mt-1 text-xs text-gray-500">
          {{ form.comment.length }} / 2000 caractere (poți folosi până la 2000)
        </p>
      </div>
      <p v-if="error" class="text-red-600 text-sm">{{ error }}</p>
      <p v-if="success" class="text-green-600 text-sm">Mulțumim pentru recenzie!</p>
      <p v-if="cooldownSeconds > 0" class="text-gray-600 text-sm">
        Poți trimite o nouă recenzie peste {{ cooldownSeconds }} secunde.
      </p>
      <button
        type="submit"
        :disabled="submitDisabled"
        class="w-full sm:w-auto px-6 py-3 bg-blue-600 hover:bg-blue-700 disabled:bg-gray-400 text-white font-semibold rounded-xl transition-colors"
      >
        {{ buttonLabel }}
      </button>
    </form>
  </div>
</template>

<script setup lang="ts">
import { ref, reactive, computed, onUnmounted } from 'vue'
import { createReview } from '@/api/reviews'

const COOLDOWN_MS = 60_000

const emit = defineEmits<{ submitted: [] }>()

const form = reactive({
  authorName: '',
  rating: 3,
  comment: '',
  website: '' as string
})
const sending = ref(false)
const error = ref('')
const success = ref(false)
const cooldownUntil = ref<number | null>(null)
const now = ref(Date.now())

let cooldownTimer: ReturnType<typeof setInterval> | null = null

const cooldownSeconds = computed(() => {
  if (cooldownUntil.value == null || now.value >= cooldownUntil.value) return 0
  return Math.ceil((cooldownUntil.value - now.value) / 1000)
})

const submitDisabled = computed(
  () => sending.value || (cooldownUntil.value != null && now.value < cooldownUntil.value)
)

const buttonLabel = computed(() => {
  if (sending.value) return 'Se trimite...'
  if (cooldownSeconds.value > 0) return `Așteaptă ${cooldownSeconds.value}s`
  return 'Trimite recenzia'
})

function startCooldown() {
  cooldownUntil.value = Date.now() + COOLDOWN_MS
  now.value = Date.now()
  if (cooldownTimer) clearInterval(cooldownTimer)
  cooldownTimer = setInterval(() => {
    now.value = Date.now()
    if (now.value >= (cooldownUntil.value ?? 0)) {
      cooldownUntil.value = null
      if (cooldownTimer) {
        clearInterval(cooldownTimer)
        cooldownTimer = null
      }
    }
  }, 1000)
}

onUnmounted(() => {
  if (cooldownTimer) clearInterval(cooldownTimer)
})

async function submit() {
  error.value = ''
  success.value = false
  if (form.rating < 1 || form.rating > 5) {
    error.value = 'Alege un rating între 1 și 5.'
    return
  }
  if (form.website.trim() !== '') {
    return
  }
  sending.value = true
  try {
    await createReview({
      authorName: form.authorName.trim(),
      rating: form.rating,
      comment: form.comment.trim(),
      website: form.website.trim() || undefined
    })
    success.value = true
    form.authorName = ''
    form.rating = 3
    form.comment = ''
    form.website = ''
    startCooldown()
    emit('submitted')
  } catch (e) {
    error.value = e instanceof Error ? e.message : 'A apărut o eroare.'
  } finally {
    sending.value = false
  }
}
</script>
