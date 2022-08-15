import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';

import {BrowserRouter as Router, Switch, Route} from "react-router-dom";
import {
    NavigationBar, Home, Login, Register, Schedule, BookingStep1, BookingStep2, BookingStep3,
    AddEvent, EditEvent, AddTeam, AccountPage, OptionsPage, Bookings, PasswordChange, LiveChat
} from "./pages/index";


function App() {


    return (
        <div className="App">
            <div className="c1-home">
                <Router>
                    <NavigationBar/>
                    <Switch>
                        <Route exact path="/test"> <BookingStep2/> </Route>
                        {sessionStorage.getItem('accessToken') ?
                            <>
                                <Route exact path="/"> <Home/> </Route>
                                <Route exact path="/livechat"> <LiveChat/> </Route>
                                <Route exact path="/options"> <OptionsPage/> </Route>
                                <Route exact path="/account"> <AccountPage/> </Route>
                                <Route exact path="/passwordChange"> <PasswordChange/> </Route>
                                <Route exact path="/bookings"> <Bookings/> </Route>
                                <Route exact path="/schedule"> <Schedule/> </Route>
                                <Route exact path="/event/:id"> <BookingStep1/> </Route>
                                <Route exact path="/event/:id/category/:categoryId"> <BookingStep2/> </Route>
                                <Route exact path="/event/:id/category/:categoryId/block/:blockId"> <BookingStep3/> </Route>

                                {sessionStorage.getItem('role') === "ADMIN" &&
                                <>
                                    <Route exact path="/addEvent"> <AddEvent/> </Route>
                                    <Route exact path="/editEvent/:id"> <EditEvent/> </Route>
                                    <Route exact path="/addTeam"> <AddTeam/> </Route>
                                </>
                                }
                            </>
                            :
                            <>
                                <Route exact path="/"> <Home/> </Route>
                                <Route exact path="/register"> <Register/> </Route>
                                <Route exact path="/login"> <Login/> </Route>
                            </>

                        }
                    </Switch>
                </Router>
            </div>
        </div>
    )
}

export default App;