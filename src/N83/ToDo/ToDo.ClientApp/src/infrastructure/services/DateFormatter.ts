export class DateFormatter {

    public static formatHumanize(date: Date): string {
        date = new Date(date);
        const now = new Date();

        const dayOfWeek = date.getDay();
        const startOfWeek = new Date(now.getFullYear(), now.getMonth(), now.getDate() - now.getDay());
        const endOfWeek = new Date(now.getFullYear(), now.getMonth(), now.getDate() + (6 - now.getDay()));
        const isThisWeek = date >= startOfWeek && date <= endOfWeek;
        const isThisYear = date.getFullYear() === now.getFullYear();

        const dayNames = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];
        const monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];

        let formattedDate = '';
        if (isThisWeek) {
            formattedDate += dayNames[dayOfWeek] + ', ';
        }

        formattedDate += monthNames[date.getMonth()] + ' ' + date.getDate();

        if (!isThisYear) {
            formattedDate += ' ' + date.getFullYear();
        }

        let hours = date.getHours();
        const minutes = date.getMinutes();
        const ampm = hours >= 12 ? 'PM' : 'AM';
        hours = hours % 12;
        hours = hours ? hours : 12;

        const formattedTime = `${hours}:${minutes < 10 ? '0' + minutes : minutes} ${ampm}`;

        return `${formattedDate} ${formattedTime}`;
    }
}