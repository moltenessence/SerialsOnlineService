import { axiosInstance } from '../utils/axios';
import { ISubscription } from '../Common/Models/ISubscription';

class SubscriptionsService {
    public static async getAll(): Promise<Array<ISubscription>> {
        const result = await axiosInstance.get(`api/Subscription/all`).
            then((response) => response.data);
        return result;
    }

    public static async getById(id: number){
        const result = await axiosInstance.get<ISubscription>(`api/Subscription/${id}`).
            then((response) => response.data);
        return result;
    }
}

export default SubscriptionsService;