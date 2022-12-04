import React, { useState, useEffect } from 'react';
import SerialModal from './modals/SerialModal';
import InfoButton from "./other/InfoButton";
import { SerialsWrapper, SerialItem, Available } from "./styles/Serials.style";
import { Dispatch, bindActionCreators } from "redux";
import { RootState } from "../redux/store";
import { ReactJSXIntrinsicAttributes } from '@emotion/react/types/jsx-namespace';
import * as serialsActionCreators from '../redux/Serials/actionCreators'
import * as userActionCreators from '../redux/User/actionCreators'
import { getIsFetching, getSerials, getModalContent, getRatings, getGenres } from '../redux/Serials/selectors';
import Preloader from './other/Preloader';
import { connect } from 'react-redux';
import { ISerial } from '../Common/Models/ISerial';
import { NavLink } from "react-router-dom";
import { RoutePaths } from '../Common/Routes';
import { getUser } from '../redux/User/selectors';
import SerialsFilterForm from './forms/SerialsFilterForm';
import GenresButton from './other/GenresButton';

function mapStateToProps(state: RootState) {
    return {
        serials: getSerials(state),
        isFetching: getIsFetching(state),
        modalContent: getModalContent(state),
        ratings: getRatings(state),
        user: getUser(state),
    };
}

const mapDispatchToProps = (dispatch: Dispatch) => bindActionCreators({
    fetchSerials: serialsActionCreators.fetchSerials,
    fetchSerialById: serialsActionCreators.fetchSerialById,
    rateSerial: serialsActionCreators.rateSerial,
    fetchUser: userActionCreators.fetchUser,
    filterSerials: serialsActionCreators.filterSerials,
}, dispatch);

type SerialsProps = ReturnType<typeof mapStateToProps> & ReturnType<typeof mapDispatchToProps> & ReactJSXIntrinsicAttributes

const Serials: React.FC<SerialsProps> = ({ serials, isFetching, fetchSerials, fetchSerialById, filterSerials, modalContent, ratings, user, rateSerial, fetchUser }) => {
    useEffect(() => {
        fetchSerials();
        fetchUser();
    }, []);

    const [isSerialInfoOpened, openSerialInfo] = useState<boolean>(false);
    const userSubscriprionId: number = user?.subscriptionId as number;

    const serialsList = serials.map((serial: ISerial) => {
        return (
            <SerialItem key={serial.id}>
                <h3>{serial.name}</h3>
                <p>Amount of series: {serial.amountOfSeries}</p>
                <p>Released: {serial.releaseYear}</p>
                <p>Genre: {serial.genre}</p>

                <NavLink to={RoutePaths.SerialsRoute + '/' + serial.id}>
                    <InfoButton callback={() => {
                        openSerialInfo(true);
                        fetchSerialById(serial.id);
                    }} />
                </NavLink>
                {userSubscriprionId >= serial?.subscriptionId! ? <Available>Available</Available> : null}
            </SerialItem>
        );
    });

    return (
        <React.Fragment>
            {user ? 
            <SerialsWrapper>
                <div>
                <SerialsFilterForm filterData={filterSerials} />
            </div>
                {isFetching ? <Preloader /> : null}
                <div>
                    {isSerialInfoOpened ? <SerialModal openSerialInfo={openSerialInfo} serialInfo={modalContent} ratings={ratings} rateSerial={rateSerial} /> : null}
                    <NavLink to={RoutePaths.SerialsRoute + '/genres'}>
                    <GenresButton callback={() => { }} />
                </NavLink>
                
                    {serialsList.length ? serialsList : <p>No serials.</p>}
                </div>
            </SerialsWrapper>
            : <p>You need to login.</p>}
        </React.Fragment>
    );
};


export default connect(mapStateToProps, mapDispatchToProps)(Serials);