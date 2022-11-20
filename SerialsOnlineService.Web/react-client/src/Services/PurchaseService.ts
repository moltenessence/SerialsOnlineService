import { axiosInstance } from '../utils/axios';
import { ISerial } from '../Common/Models/ISerial';
import { IPurchase } from '../Common/Models/IPurchase';

class PurchaseService {
    public static async getByUserId(userId: number): Promise<Array<IPurchase>> {
        const result = await axiosInstance.get(`api/Purchase/user/${userId}`).
            then((response) => response.data);
        return result;
    }
}

export default PurchaseService;