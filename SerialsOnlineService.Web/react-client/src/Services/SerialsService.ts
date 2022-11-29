import { axiosInstance } from '../utils/axios';
import { ISerial } from '../Common/Models/ISerial';
import { ISerialWithRatings } from '../Common/Models/ISerialWithRatings';

class SerialsService {
    public static async getAll(): Promise<Array<ISerial>> {
        const result = await axiosInstance.get(`api/Serial/all`).
            then((response) => response.data);
        return result;
    }

    public static async getById(id: number): Promise<ISerialWithRatings> {
        const result = await axiosInstance.get(`api/Serial/ratings/${id}`).
            then((response) => response.data);
        return result;
    }
}

export default SerialsService;