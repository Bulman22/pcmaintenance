import { onMounted } from 'vue'
import { useRoute, useRouter } from 'vue-router'

/**
 * Scrolls the page to the element with the given id (smooth).
 */
function scrollToSection(sectionId: string): void {
  document.getElementById(sectionId)?.scrollIntoView({ behavior: 'smooth' })
}

/**
 * Composable for scroll-to-section behavior: direct scroll and navigate-then-scroll (for header).
 */
export function useScrollToSection() {
  const router = useRouter()

  function navigateToSection(sectionId: string): void {
    if (router.currentRoute.value.path === '/') {
      scrollToSection(sectionId)
    } else {
      router.push('/').then(() => {
        setTimeout(() => scrollToSection(sectionId), 100)
      })
    }
  }

  return { scrollToSection, navigateToSection }
}

/**
 * On mount, if the route has a hash (e.g. /#contact), scrolls to that section.
 */
export function useScrollToHashOnMount(): void {
  const route = useRoute()
  onMounted(() => {
    if (route.hash) {
      const id = route.hash.substring(1)
      setTimeout(() => scrollToSection(id), 100)
    }
  })
}
