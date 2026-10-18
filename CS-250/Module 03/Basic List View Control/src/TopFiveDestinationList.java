import java.awt.*;
import javax.swing.*;
import javax.swing.border.*;

public class TopFiveDestinationList {
    public static void main(String[] args) {
        SwingUtilities.invokeLater(new Runnable() {
            public void run() {
            	TopDestinationListFrame topDestinationListFrame = new TopDestinationListFrame();
                topDestinationListFrame.setTitle("Top 5 Destination List");
                topDestinationListFrame.setVisible(true);
            }
        });
    }
}


class TopDestinationListFrame extends JFrame {
    private DefaultListModel listModel;

    public TopDestinationListFrame() {
        super("Top Five Destination List");

        setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        setSize(900, 750);

        listModel = new DefaultListModel();


        // List updated to include Top 5 Destinations in Japan - BM (2026/05/24)
        addDestinationNameAndPicture(
            "1. Tokyo - Tokyo offers modern city life, shopping districts, anime culture, and world-famous cuisine. Learn more: https://en.japantravel.com/tokyo", 
            new ImageIcon(getClass().getResource("/resources/Tokyo.jpg")));
        addDestinationNameAndPicture(
            "2. Kyoto - Kyoto is known for historic temples, bamboo forests, and traditional Japanese culture. Learn more: https://en.japantravel.com/kyoto", 
            new ImageIcon(getClass().getResource("/resources/Kyoto.jpg")));
        addDestinationNameAndPicture(
            "3. Osaka - Osaka is famous for street food, nightlife, and entertainment districts like Dotonbori. Learn more: https://en.japantravel.com/osaka", 
            new ImageIcon(getClass().getResource("/resources/Osaka.jpg")));
        addDestinationNameAndPicture(
            "4. Hokkaido - Hokkaido features mountain scenery, skiing, hot springs, and beautiful winter festivals. Learn more: https://en.japantravel.com/hokkaido", 
            new ImageIcon(getClass().getResource("/resources/Hokkaido.jpg")));
        addDestinationNameAndPicture(
            "5. Okinawa - Okinawa offers tropical beaches, island culture, and relaxing ocean resorts. Learn more: https://en.japantravel.com/okinawa", 
            new ImageIcon(getClass().getResource("/resources/Okinawa.jpg")));
        
        JList list = new JList(listModel);

        TextAndIconListCellRenderer renderer = new TextAndIconListCellRenderer(2);

        list.setCellRenderer(renderer);

        // Japan-inspired color customization - BM (2026/05/24)
        list.setBackground(new Color(245, 245, 245));
        list.setSelectionBackground(new Color(188, 0, 45));
        list.setSelectionForeground(Color.WHITE);
        list.setFont(new Font("Serif", Font.PLAIN, 14));
        list.setFixedCellHeight(125);

        JScrollPane scrollPane = new JScrollPane(list);

        JLabel nameLabel = new JLabel(
            "SNHU Travel - Top Five Destinations in Japan | Blake Merry",
            JLabel.CENTER
        );

        nameLabel.setFont(new Font("Serif", Font.BOLD, 20));
        nameLabel.setForeground(new Color(188, 0, 45));

        getContentPane().add(nameLabel, BorderLayout.NORTH);
        getContentPane().add(scrollPane, BorderLayout.CENTER);
    }

    private void addDestinationNameAndPicture(String text, Icon icon) {
        TextAndIcon tai = new TextAndIcon(text, icon);
        listModel.addElement(tai);
    }
}


class TextAndIcon {
    private String text;
    private Icon icon;

    public TextAndIcon(String text, Icon icon) {
        this.text = text;
        this.icon = icon;
    }

    public String getText() {
        return text;
    }

    public Icon getIcon() {
        return icon;
    }

    public void setText(String text) {
        this.text = text;
    }

    public void setIcon(Icon icon) {
        this.icon = icon;
    }
}


class TextAndIconListCellRenderer extends JLabel implements ListCellRenderer {
    private static final Border NO_FOCUS_BORDER = new EmptyBorder(1, 1, 1, 1);

    private Border insideBorder;

    public TextAndIconListCellRenderer() {
        this(0, 0, 0, 0);
    }

    public TextAndIconListCellRenderer(int padding) {
        this(padding, padding, padding, padding);
    }

    public TextAndIconListCellRenderer(int topPadding, int rightPadding, int bottomPadding, int leftPadding) {
        insideBorder = BorderFactory.createEmptyBorder(topPadding, leftPadding, bottomPadding, rightPadding);
        setOpaque(true);
    }

    public Component getListCellRendererComponent(JList list, Object value,
    int index, boolean isSelected, boolean hasFocus) {
        // The object from the combo box model MUST be a TextAndIcon.
        TextAndIcon tai = (TextAndIcon) value;

        // Sets text and icon on 'this' JLabel.
        setText(tai.getText());
        setIcon(tai.getIcon());

        if (isSelected) {
            setBackground(list.getSelectionBackground());
            setForeground(list.getSelectionForeground());
        } else {
            setBackground(list.getBackground());
            setForeground(list.getForeground());
        }

        Border outsideBorder;

        if (hasFocus) {
            outsideBorder = UIManager.getBorder("List.focusCellHighlightBorder");
        } else {
            outsideBorder = NO_FOCUS_BORDER;
        }

        setBorder(BorderFactory.createCompoundBorder(outsideBorder, insideBorder));
        setComponentOrientation(list.getComponentOrientation());
        setEnabled(list.isEnabled());
        setFont(list.getFont());

        return this;
    }

    // The following methods are overridden to be empty for performance
    // reasons. If you want to understand better why, please read:
    //
    // http://java.sun.com/javase/6/docs/api/javax/swing/DefaultListCellRenderer.html#override

    public void validate() {}
    public void invalidate() {}
    public void repaint() {}
    public void revalidate() {}
    public void repaint(long tm, int x, int y, int width, int height) {}
    public void repaint(Rectangle r) {}
}