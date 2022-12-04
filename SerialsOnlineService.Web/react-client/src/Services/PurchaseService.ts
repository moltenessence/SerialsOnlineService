import { axiosInstance } from '../utils/axios';
import { IPurchase } from '../Common/Models/IPurchase';
import { IMakePurchaseRequest } from '../Common/Requests/IMakePurchaseRequest';
import { AxiosError } from 'axios';

class PurchaseService {
    public static async getByUserId(userId: number): Promise<Array<IPurchase>> {
        const result = await axiosInstance.get(`api/Purchase/user/${userId}`).
            then((response) => response.data);
        return result;
    }

    public static async deleteById(id: number) {
        const result = await axiosInstance.delete<IPurchase>(`api/Purchase/${id}`).
            then((response) => response.data);
        return result;
    }

    public static async makePurchase(request: IMakePurchaseRequest)  {
        const result = await axiosInstance.post<IPurchase>(`api/Purchase`, {...request}).
            then((response) => response.data).
            catch((error : AxiosError)=>{
                console.log(error);
                const errorMessage = error.response?.data?.toString();

                alert(errorMessage?.split('.')[0]);
            }
            );
        return result;
    }
}

export default PurchaseService;