import { api } from '../services/AxiosService'
import { AppState } from '../AppState'
class BurgerService {
  async getAllBurgers() {
    const res = await api.get('api/burger')
    AppState.burgers = res.data
  }
}

export const burgerService = new BurgerService()
