import { useEffect, useState } from 'react';
import { getUser, isFetching } from '../redux/User/selectors';
import { RootState } from '../redux/store';
import { Dispatch, bindActionCreators } from 'redux';
import * as  userActionCreators from '../redux/User/actionCreators';
import { ReactJSXIntrinsicAttributes } from '@emotion/react/types/jsx-namespace';
import Preloader from './other/Preloader';
import { connect } from 'react-redux';
import { AccountWrapper, AccountItem, AccountHeader, AccountField } from './styles/Account.style';
import UpdateButton from './other/UpdateButton';
import UpdateUserForm from './forms/UpdateUserForm';


function mapStateToProps(state: RootState) {
    return {
        user: getUser(state),
        isFetching: isFetching(state),
    };
}

const mapDispatchToProps = (dispatch: Dispatch) => bindActionCreators({
    fetchUser: userActionCreators.fetchUser,
    updateUser: userActionCreators.updateUser,
}, dispatch);

type AccountProps = ReturnType<typeof mapStateToProps> & ReturnType<typeof mapDispatchToProps> & ReactJSXIntrinsicAttributes

const Account: React.FC<AccountProps> = ({ user, isFetching, fetchUser, updateUser }) => {

    const [isFormOpened, setFormOpened] = useState(false);

    useEffect(() => {
        fetchUser();
    }, [user]);

    return (
        <AccountWrapper>
            {isFetching ? <Preloader /> : null}
            <h1>Account</h1>
            {user ? <AccountItem>
                <AccountHeader>{user.userName}</AccountHeader>
                <AccountField>Email: {user.email}</AccountField>
                <AccountField>Age: {user.age}</AccountField>
                <UpdateButton callback={() => {
                    setFormOpened(!isFormOpened);
                }} />

                {isFormOpened && <UpdateUserForm user={user} updateUser={updateUser}/>}
            </AccountItem> : 'You need to login.'
            }
        </AccountWrapper>
    );
};

export default connect(mapStateToProps, mapDispatchToProps)(Account);