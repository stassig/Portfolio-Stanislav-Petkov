import teamLogo from "../images/logos/logo1.png";


const Ticket = ({ticketId, date, time, category, blockNumber, seats, pricePerSeat, totalPrice, ticketOwner, league, eventId, username, teamName, logo}) => {


    return (
        <>
            <div className="ticket-container">
                <div className="booking-details-container">
                    <div><b>TICKET NUMBER:</b> {ticketId}</div>
                    <div><b>DATE:</b> {date}</div>
                    <div><b>TIME:</b> {time}</div>
                    <div><b>CATEGORY:</b>{category === "Standing" ? " " + category : category}</div>
                    <div><b>BLOCK:</b> {blockNumber}</div>
                    <div><b>SEAT(S):</b> {seats}</div>
                    <div><b>PRICE PER SEAT:</b> {pricePerSeat.toFixed(2)} €</div>
                    <div><b>TOTAL PRICE:</b> {totalPrice.toFixed(2)} €</div>
                    <div><b>TICKET OWNER:</b> {ticketOwner}</div>
                </div>

                <div className="event-details">
                    <div className="booking-league-name">{league}</div>
                    <div className="team-logos-container">
                        <div>
                            <img src={teamLogo} className="img-team-booking" alt="Logo"/>
                            <div>(BAYERN MUNICH)</div>
                        </div>
                        <div className="vs-tag-booking"><b>vs</b></div>
                        <div>
                            <img src={process.env.PUBLIC_URL + logo} className="img-team-booking" alt="Logo"/>
                            <div>({teamName})</div>
                        </div>
                    </div>
                    <div className="booking-stadium">ALLIANZ ARENA</div>
                </div>
            </div>
        </>
    )
}

export default Ticket;