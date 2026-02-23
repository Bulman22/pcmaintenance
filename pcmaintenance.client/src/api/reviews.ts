import type { Review, CreateReviewRequest } from '@/types/review'

const baseUrl = import.meta.env.VITE_API_BASE_URL ?? ''

async function request<T>(path: string, options?: RequestInit): Promise<T> {
  const url = baseUrl ? `${baseUrl}${path}` : path
  const res = await fetch(url, {
    ...options,
    headers: {
      'Content-Type': 'application/json',
      ...options?.headers,
    },
  })
  if (!res.ok) {
    if (res.status === 429) {
      throw new Error(
        'Prea multe recenzii trimise. Poți trimite din nou o recenzie peste aproximativ o oră.'
      )
    }
    const err = await res.json().catch(() => ({ error: res.statusText }))
    throw new Error((err as { error?: string }).error ?? res.statusText)
  }
  return res.json() as Promise<T>
}

export function getReviews(): Promise<Review[]> {
  return request<Review[]>('/api/reviews')
}

export function createReview(data: CreateReviewRequest): Promise<Review> {
  return request<Review>('/api/reviews', {
    method: 'POST',
    body: JSON.stringify(data),
  })
}
