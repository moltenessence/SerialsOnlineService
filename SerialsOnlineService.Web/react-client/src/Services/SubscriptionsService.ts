import { axiosInstance } from "../utils/axios";
import { ISubscription } from "../Common/Models/ISubscription";
import { ISubscriptionFilter } from "../Common/Models/ISubscriptionsFilter";
import { PriceFilterOptions } from "../Common/Enums/PriceFilterOptions";

class SubscriptionsService {
  public static async getAll(): Promise<Array<ISubscription>> {
    const result = await axiosInstance
      .get(`api/Subscription/all`)
      .then((response) => response.data);

    return result;
  }

  public static async getById(id: number) {
    const result = await axiosInstance
      .get<ISubscription>(`api/Subscription/${id}`)
      .then((response) => response.data);

    return result;
  }

  public static async getByPrice(filter: ISubscriptionFilter) {
    if (filter.priceFilterOption == PriceFilterOptions.All) {
      let result = await this.getAll();

      return result;
    }

    const subscription = await axiosInstance
      .get<ISubscription>(`api/Subscription/price/${filter.priceFilterOption}`)
      .then((response) => response.data);
    const result: Array<ISubscription> = [subscription];

    return result;
  }
}

export default SubscriptionsService;
