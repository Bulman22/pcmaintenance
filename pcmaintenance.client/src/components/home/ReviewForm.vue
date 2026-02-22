<template>
  <div class="mt-10 bg-white rounded-2xl p-6 sm:p-8 shadow-xl border border-gray-100">
    <h3 class="text-2xl font-bold text-gray-900 mb-6 text-center">Lasă-ne o recenzie</h3>
    <form @submit.prevent="submit" class="space-y-4 max-w-xl mx-auto">
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
          rows="4"
          class="w-full rounded-lg border border-gray-300 px-4 py-2 focus:ring-2 focus:ring-blue-500 focus:border-blue-500"
          placeholder="Spune-ne ce părere ai despre serviciile noastre..."
        />
      </div>
      <p v-if="error" class="text-red-600 text-sm">{{ error }}</p>
      <p v-if="success" class="text-green-600 text-sm">Mulțumim pentru recenzie!</p>
      <button
        type="submit"
        :disabled="sending"
        class="w-full sm:w-auto px-6 py-3 bg-blue-600 hover:bg-blue-700 disabled:bg-gray-400 text-white font-semibold rounded-xl transition-colors"
      >
        {{ sending ? 'Se trimite...' : 'Trimite recenzia' }}
      </button>
    </form>
  </div>
</template>

<script setup lang="ts">
import { ref, reactive } from 'vue'
import { createReview } from '@/api/reviews'

const emit = defineEmits<{ submitted: [] }>()

const form = reactive({
  authorName: '',
  rating: 3,
  comment: ''
})
const sending = ref(false)
const error = ref('')
const success = ref(false)

async function submit() {
  error.value = ''
  success.value = false
  if (form.rating < 1 || form.rating > 5) {
    error.value = 'Alege un rating între 1 și 5.'
    return
  }
  sending.value = true
  try {
    await createReview({
      authorName: form.authorName.trim(),
      rating: form.rating,
      comment: form.comment.trim()
    })
    success.value = true
    form.authorName = ''
    form.rating = 3
    form.comment = ''
    emit('submitted')
  } catch (e) {
    error.value = e instanceof Error ? e.message : 'A apărut o eroare.'
  } finally {
    sending.value = false
  }
}
</script>
