import { useEffect } from 'react';
import { getUser, isFetching } from '../redux/User/selectors';
import { RootState } from '../redux/store';
import { Dispatch, bindActionCreators } from 'redux';
import * as  userActionCreators from '../redux/User/actionCreators';
import { ReactJSXIntrinsicAttributes } from '@emotion/react/types/jsx-namespace';
import Preloader from './other/Preloader';
import { connect } from 'react-redux';
import { AccountWrapper } from './styles/Account.style';

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

    useEffect(() => {
        fetchUser();
    }, [user]);

    return (
        <div>
            {isFetching ? <Preloader /> : null}
            {user ? <AccountWrapper>
                <h1>Account</h1>
                <h3>{user.userName}</h3>
                <p>Email: {user.email}</p>
                <p>Age: {user.age}</p>
            </AccountWrapper> : 'You need to login.'}
        </div>
    );
};

export default connect(mapStateToProps, mapDispatchToProps)(Account);