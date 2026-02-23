export interface Review {
  id: number
  authorName: string
  rating: number
  comment: string
  createdAt: string
}

export interface CreateReviewRequest {
  authorName: string
  rating: number
  comment: string
  /** Honeypot: must be empty; bots often fill it. */
  website?: string
}
