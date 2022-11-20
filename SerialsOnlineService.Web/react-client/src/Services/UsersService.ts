import { axiosInstance } from '../utils/axios';
import { IUpdateUserRequest, IUser } from '../Common/Models/IUser';

class UsersService {
    public static async update(user : IUpdateUserRequest): Promise<void> {
        const result = await axiosInstance.put(`api/Users/${user.id}`, user).
            then((response) => response.data)
            .catch((error) => {
                console.log(error);
            });
        return result;
    }

    public static async getById(id: number): Promise<IUser> {
        const result = await axiosInstance.get(`api/Users/${id}`).
            then((response) => response.data);
        return result;
    }
}

export default UsersService;